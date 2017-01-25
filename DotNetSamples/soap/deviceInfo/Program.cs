/////////////////////////////////////////////////////////////////////////////////////////////
//
// Codeproof MDM API SDK sample program. 
//
// Copyright (C) 2013, Codeproof Technologies Inc. All rights reserved. http://codeproof.com 
//
// Email us at support@codeproof.com for questions/comments/feedback.
//    
//////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DeviceInfo.CodeproofService;

namespace CodeproofSDKSample
{
    class Program
    {
        static void Main(string[] args)
        {

            Authenticate AuthObj = new Authenticate();

            AuthObj.userid = "--your account login email goes here--";
            AuthObj.apikey = "--your API key goes here--"; //API key is available here at "https://www.codeproof.com/console/Account/Login?ReturnUrl=/console/MyAccount/Index" 

            CodeproofServiceClient cpservice = new CodeproofServiceClient();

            //get CPIDs

            CPID[] cpids = cpservice.GetCPIDs(AuthObj);

            foreach (CPID record in cpids)
            {

                //Query each device properties from Codeproof Cloud.

                DeviceProperty dp = cpservice.GetDeviceProperty(AuthObj, record);


                Console.WriteLine("\n\n");
                Console.WriteLine("=== Device [ " + dp.DeviceName + "] Data ===");
                Console.WriteLine("\n\n");

                //Show Device Ids
                Console.WriteLine("cpid=" + record.cpid);
                Console.WriteLine("devicetype=" + record.devicetype);
                Console.WriteLine("deviceid=" + record.deviceid);

                //Show Device Properties
                Console.WriteLine("\n");
                Console.WriteLine("---Device Properties -->");
                Console.WriteLine("\n");
                foreach (NameValue prop in dp.DeviceInformations)
                {
                    Console.WriteLine(prop.Name + " = " + prop.Value);                
                }

                //Show Installed Apps
                Console.WriteLine("\n");
                Console.WriteLine("---Installed Applications -->");
                Console.WriteLine("\n");
                foreach (App app in dp.InstalledApplications)
                {
                    Console.WriteLine("App Name = " + app.AppName);
                    Console.WriteLine("App Version = " + app.Version);
                    Console.WriteLine("App Package = " + app.PackageName);
                    Console.WriteLine("");
                }

                //Show iOS running programs
                Console.WriteLine("\n");
                Console.WriteLine("---iOS Running Programs -->");
                Console.WriteLine("\n");
                foreach (Process process in dp.RunningProcess)
                {
                    Console.WriteLine("Process Name = " + process.Name);
                    Console.WriteLine("Process Id = " + process.Pid);
                    Console.WriteLine("Process Started At = " + process.ProcessStartedAt);
                    Console.WriteLine("");
                }

                //Show Android Running Apps
                Console.WriteLine("\n");
                Console.WriteLine("---Android Running Applications -->");
                Console.WriteLine("\n");
                foreach (App app in dp.RunningApplications)
                {
                    Console.WriteLine("App Name = " + app.AppName);
                    Console.WriteLine("App Version = " + app.Version);
                    Console.WriteLine("App Package = " + app.PackageName);
                    Console.WriteLine("");
                }

                //Show Android Running Services
                Console.WriteLine("\n");
                Console.WriteLine("---Android Running Services -->");
                Console.WriteLine("\n");
                foreach (App app in dp.RunningServices)
                {
                    Console.WriteLine("App Name = " + app.AppName);
                    Console.WriteLine("App Version = " + app.Version);
                    Console.WriteLine("App Package = " + app.PackageName);
                    Console.WriteLine("");
                }
            }
        }
    }
}
