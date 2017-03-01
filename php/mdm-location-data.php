<?php

echo "Initializing<br>";
ini_set('display_errors', 'On');
error_reporting(E_ALL);

/* Initialize webservice with Codeproof WSDL */

echo "Configuring WSDL<br>";

$soap_options = array(
        'trace'       => 1,     // traces let us look at the actual SOAP messages later
        'exceptions'  => 1 );

$wsdl = "https://www.codeproof.com/webservice/public/v1/CodeproofService.svc?singleWsdl";

$client = new SoapClient($wsdl, $soap_options);


/*****Specify SDK authentication info*************/

$authparam = new StdClass();
$authparam->userid = 'enter account email-id';
$authparam->apikey = 'enter api key here'; /*** API key can be obtained from Cloud Console here https://www.codeproof.com/console/Account/Login?ReturnUrl=/console/MyAccount/Index  ***/ 


/* Invoke webservice method with auth obj, in this case: GetCPIDs */
echo "Getting all the device id's <br>";
$result = $client->GetCPIDs(array("AuthObj" => objectToArray($authparam)))->GetCPIDsResult;

$resultarray = $result->CPID;

/* function GetCPIDs returns array of CPID objects */

$numdevices = count($resultarray);


/***************
NOTE: Wakeup all the devices in the "Samsung Devices" group. So that you can get a fresh location data. 
******************/

echo "Waking up devices...<br>";

$params = array("AuthObj" => objectToArray($authparam), "nodename" => 'Samsung Devices');	

$result = $client->PingDevice($params)->PingDeviceResult;	

	
	
/********** 

NOTE: In this sample code, We are querying device info and location history 

**********/
	
for($x = 0; $x < $numdevices; $x++) 
{
	/* Each cpid contains single device identifier info **/	
	
	$cpidparam = new StdClass();
	$cpidparam->cpid = $resultarray[$x]->cpid;
	$cpidparam->deviceid = $resultarray[$x]->deviceid;
	$cpidparam->devicetype = $resultarray[$x]->devicetype;
	
	
	/** pass AuthObj, CPID object to GetDeviceProperty method **/
	
	$params = array("AuthObj" => objectToArray($authparam), "cpid" => objectToArray($cpidparam));
			
	/******* Query device properties *******/
		
	$deviceProps = $client->GetDeviceProperty($params)->GetDevicePropertyResult;

	echo "Device Id - {$deviceProps->AgentId}<br>";
	echo "Device Properties ---> <br>";
	echo "Device Name - {$deviceProps->DeviceName} <br>";	
	echo "Phone Number - {$deviceProps->PhoneNumber} <br>";
	echo "Last Checkin Time - {$deviceProps->LastCheckinTime} <br>";
	echo "Screenlock Status - {$deviceProps->ScreenlockStatus} <br>";
		
	echo "Location Data ---><br>";
	
	/******* Query Location data *******/
	
	$locationResult = $client->GetLocationInfo($params)->GetLocationInfoResult;

	if(count((array)$locationResult))
	{ 
		$locationArray = $locationResult->LocationInfo; 
	
		/** Dump all the location data. array[0] contains current location *****************/
			
		foreach ($locationArray as $loc)
		{ 			
			echo "Longitude = {$loc->Longitude}<br>";	
		
			echo "Latitude = {$loc->Latitude}<br>";
							
			echo "Accuracy = {$loc->Accuracy} Meters<br>";
			
			echo "ReportedTime(UTC) = {$loc->ReportedTime}<br>";
					
		}

	}
	echo "<br>";
		
}

echo "Done!<br>";


/******************Helper methods************************/

function objectToArray($d) {
		if (is_object($d)) {
			// Gets the properties of the given object
			// with get_object_vars function
			$d = get_object_vars($d);
		}
 
		if (is_array($d)) {
			/*
			* Return array converted to object
			* Using __FUNCTION__ (Magic constant)
			* for recursive call
			*/
			return array_map(__FUNCTION__, $d);
		}
		else {
			// Return array
			return $d;
		}
	}
	
function arrayToObject($d) {
		if (is_array($d)) {
			/*
			* Return array converted to object
			* Using __FUNCTION__ (Magic constant)
			* for recursive call
			*/
			return (object) array_map(__FUNCTION__, $d);
		}
		else {
			// Return object
			return $d;
		}
	}	

?>
