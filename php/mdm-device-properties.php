<?php

echo "Initializing\n";
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
$authparam->userid = 'enter user id';
$authparam->apikey = 'enter api key'; /*** API key can be obtained from Cloud Console here https://www.codeproof.com/console/Account/Login?ReturnUrl=/console/MyAccount/Index  ***/ 


/* Invoke webservice method with auth obj, in this case: GetCPIDs */
echo "Getting all the device id's <br>";
$result = $client->GetCPIDs(array("AuthObj" => objectToArray($authparam)))->GetCPIDsResult;

$resultarray = $result->CPID;

/* function GetCPIDs returns array of CPID objects */

$numdevices = count($resultarray);


	
/********** 

NOTE: In this sample code, We are querying varous device properties. 

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
	
		
	$deviceProps = $client->GetDeviceProperty($params)->GetDevicePropertyResult;

	echo "Device Id - {$deviceProps->AgentId}<br>";
	echo "Device Properties ---> <br>";
	echo "Device Name - {$deviceProps->DeviceName} <br>";	
	echo "Phone Number - {$deviceProps->PhoneNumber} <br>";
	echo "Last Checkin Time - {$deviceProps->LastCheckinTime} <br>";
	echo "Screenlock Status - {$deviceProps->ScreenlockStatus} <br>";
		
	foreach ($deviceProps->DeviceInformations as $namevalues)
	{  
			
		for ($y = 0; $y < count($namevalues); $y++)
		{ 
			/*** dump all the property name/vaules ***/
	
			echo "{$namevalues[$y]->Name} - {$namevalues[$y]->Value}<br>";	
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
