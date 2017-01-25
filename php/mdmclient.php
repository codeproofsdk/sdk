<?php

echo "Initializing\n";
ini_set('display_errors', 'On');
error_reporting(E_ALL);

/* Initialize webservice with Codeproof WSDL */

echo "Configuring WSDL\n";

$soap_options = array(
        'trace'       => 1,     // traces let us look at the actual SOAP messages later
        'exceptions'  => 1 );

$wsdl = "https://www.codeproof.com/webservice/public/v1/CodeproofService.svc?singleWsdl";

$client = new SoapClient($wsdl, $soap_options);


/*****Specify SDK authentication info*************/

$authparam = new StdClass();
$authparam->userid = 'Enter your codeproof account-email';
$authparam->apikey = 'Enter API key';


/* Invoke webservice method with auth obj, in this case: GetCPIDs */
echo "Invoking GetCPIDs\n";
$result = $client->GetCPIDs(array("AuthObj" => objectToArray($authparam)))->GetCPIDsResult;

$resultarray = $result->CPID;

/* function GetCPIDs returns array of CPID objects */

$numdevices = count($resultarray);


/*  setup CommandRecord Object. Only first field "Command" is required..rest all can be empty  */
$cmdparam = new StdClass();	
$cmdparam->Command = 'screenlock'; 
$cmdparam->CommandName = 'SDK screen lock command';
$cmdparam->AgentId = '';
$cmdparam->CommandId = '';
$cmdparam->CreatedOn = '';
$cmdparam->CreatedUserId = '';
$cmdparam->Notes = '';
$cmdparam->Param1 = '';
$cmdparam->Param2 = '';
$cmdparam->ProductId = '';
$cmdparam->Result = '';
$cmdparam->Status = '';
$cmdparam->UpdatedOn = '';

	
/********** 

NOTE: In this sample code, We are locking all the devices in this account. 

Make sure to check deviceid (UDID in case of iOS) in the cpid object to target particular device 

**********/
	
for($x = 0; $x < $numdevices; $x++) 
{
	/* Each cpid contains single device identifier info **/	
	
	$cpidparam = new StdClass();
	$cpidparam->cpid = $resultarray[$x]->cpid;
	$cpidparam->deviceid = $resultarray[$x]->deviceid;
	$cpidparam->devicetype = $resultarray[$x]->devicetype;
	
	
	/** pass AuthObj, CPID object and command objects to ExecuteCommand method **/

	echo "Invoking ExecuteCommand\n";
	
	$params = array("AuthObj" => objectToArray($authparam), "cpid" => objectToArray($cpidparam), "cmdObj" => objectToArray($cmdparam));
	
	
	$cmdresult = $client->ExecuteCommand($params)->ExecuteCommandResult;
	
	/* dump the command execution status **/  
	
	var_dump($cmdresult->Status);
	 
}

echo "Done!\n";


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
