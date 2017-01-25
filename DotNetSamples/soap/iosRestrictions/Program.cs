/////////////////////////////////////////////////////////////////////////////////////////////
//
// Codeproof MDM API SDK sample program. 
//
// Copyright (C) 2014, Codeproof Technologies Inc. All rights reserved. http://codeproof.com 
//
// Email us at support@codeproof.com for questions/comments/feedback.
//    
//////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iosRestrictions.CodeproofService;

namespace iosRestrictions
{

    class Program
    {
        static string productId = "AFF8A4F8-319F-4B45-B1F5-AB31972192A5";
        static string managedGroup = "iOS Devices";

        static void Main(string[] args)
        {

            //
            // The following sample C# code shows how to enable restriction policies programmatically. Also demonstrates time-based restrictions.
            //


            Authenticate AuthObj = new Authenticate();

            AuthObj.userid = "--your account login email goes here--";
            AuthObj.apikey = "--your API key goes here--"; //API key is available here at "https://www.codeproof.com/console/Account/Login?ReturnUrl=/console/MyAccount/Index"

            CodeproofServiceClient cpservice = new CodeproofServiceClient();

            //
            //Enable Restriction Policies
            //
            //
            // Below "SDK-Test-group" is a group name or individual node name(device name) in the Codeproof console (Mobile Policy Manager). 
            //

            string result;

            //
            // Disables camera from the device(s)
            //
            result = cpservice.AddPolicy(AuthObj, managedGroup, productId, "iOS General Policy", "allowCamera", "false");

            result = cpservice.AddPolicy(AuthObj, managedGroup, productId, "iOS Group Policy", "Deploy", "true");
            result = cpservice.AddPolicy(AuthObj, managedGroup, productId, "iOS Group Policy", "Inherit", "0");

            //
            //Turn-off camera for 60 secs only (Time based restriction policies).
            //
            //result = cpservice.AddPolicy(AuthObj, managedGroup, productId, "iOS Group Policy", "DurationUntilRemoval", "60"); 
            //


            //send policy to device
            result = cpservice.PingDevice(AuthObj, managedGroup);



            //Remove all restrictions - forcefully

            cpservice.AddPolicy(AuthObj, managedGroup, productId, "iOS Group Policy", "Deploy", "false");
            cpservice.PingDevice(AuthObj, managedGroup);
        }
    }
}
