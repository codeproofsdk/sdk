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

using iosKioskAppInstall.CodeproofService;

namespace iosKioskAppInstall
{
    class Program
    {
        static string productId = "AFF8A4F8-319F-4B45-B1F5-AB31972192A5";
        static string managedGroup = "iOS Devices";

        static CodeproofServiceClient cpservice = new CodeproofServiceClient();
        static Authenticate AuthObj = new Authenticate();


        static void Main(string[] args)
        {

            //
            // The following sample C# code shows how to enable "Single App Mode(App Lock)" programmatically in iOS device and deply an iOS app while in single app mode.
            //

            Console.WriteLine("Started!");


            AuthObj.userid = "-----your login email id------";
            AuthObj.apikey = "-----your API Key----"; //get it here "https://www.codeproof.com/console/Account/Login?ReturnUrl=/console/MyAccount/Index" 


            Console.WriteLine("Enabling single app mode for: Safari browser app (com.apple.safari)");

            EnableKiosk("com.apple.safari");

            Console.WriteLine("Waiting 30 secs...");

            System.Threading.Thread.Sleep(30000); //30 secs

            Console.WriteLine("Removing Kiosk mode...");

            RemoveKiosk();

            Console.WriteLine("Waiting 30 secs...");

            System.Threading.Thread.Sleep(30000);

            Console.WriteLine("Installing App...");

            PushSoftware();

            Console.WriteLine("Waiting 30 secs...");

            System.Threading.Thread.Sleep(30000);

            Console.WriteLine("Enabling Kiosk Mode for: com.apple.safari");

            EnableKiosk("com.apple.safari");

            Console.WriteLine("Done!");
        }



        public static void EnableKiosk(string bundleid)
        {

            string result;

            result = cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "BundleId", bundleid);
            result = cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "Deploy", "true");
            result = cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "Inherit", "0");

            //Configure Single App Policies

            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "DisableTouch", "false");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "DisableDeviceRotation", "true");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "DisableVolumeButtons", "true");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "DisableRingerSwitch", "false");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "DisableSleepWakeButton", "false");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "DisableAutoLock", "true");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "EnableVoiceOver", "false");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "EnableZoom", "false"); //enable/disable Zoom
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "EnableInvertColors", "false");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "EnableAssistiveTouch", "false");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "EnableSpeakSelection", "false");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "EnableMonoAudio", "false");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "VoiceOver", "false");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "Zoom", "false"); //Zoom adjustment
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "InvertColors", "false");
            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "AssistiveTouch", "false");

            result = cpservice.PingDevice(AuthObj, managedGroup);
        }


        public static void RemoveKiosk()
        {

            //Remove Single App Mode (App Lock) - forcefully

            cpservice.AddPolicy(AuthObj, managedGroup, productId, "App Lock", "Deploy", "false");
            cpservice.PingDevice(AuthObj, managedGroup);
        }


        public static void PushSoftware()
        {
            Software[] softwares = cpservice.GetSoftwares(AuthObj);

            string manfestUrl = "https://www.acmecorp.com/downloads/testAppManifest.plist";  // change this url to actual app manifest download url.


            if (softwares.Length == 0)
            {
                //add it first time
                cpservice.AddSoftware(AuthObj, "Test App", "Acme Corp", "iOS", manfestUrl, "ManifestUrl", "1");
            }
            else
            {

                foreach (Software soft in softwares)
                {
                    cpservice.UpdateSoftware(AuthObj, soft.Id, soft.Name, soft.Publisher, soft.OS, soft.PkgUrl, soft.PkgType, "1");
                    break;
                }
            }

            cpservice.PingDevice(AuthObj, managedGroup);
        }
    }
}
