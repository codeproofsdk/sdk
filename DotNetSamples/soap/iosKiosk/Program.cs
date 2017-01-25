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

using iosKiosk.CodeproofService;

namespace iosKiosk
{
    class Program
    {

        static string ProductId = "AFF8A4F8-319F-4B45-B1F5-AB31972192A5"; //do not change it
        static string ManagedGroup = "iOS Devices"; //change it to group name in Mobile Policy Manager

        static CodeproofServiceClient cpservice = new CodeproofServiceClient();
        static Authenticate AuthObj = new Authenticate();


        static void Main(string[] args)
        {

            //
            // The following sample C# code shows how to enable "Single App Mode(App Lock)" programmatically in iOS devices.
            //


            Authenticate AuthObj = new Authenticate();

            AuthObj.userid = "--your account login email goes here--";
            AuthObj.apikey = "--your API key goes here--"; //API key is available here at https://www.codeproof.com/console/Account/Login?ReturnUrl=/console/MyAccount/Index

            CodeproofServiceClient cpservice = new CodeproofServiceClient();

            //
            //Enable Single App Mode (App Lock) programatically
            //
            // NOTE:In order to enable Single App Mode, iOS devices must be configured as "Supervised" Devices. 
            //


            Console.WriteLine("Enabling single app mode for: Safari browser app (com.apple.safari)");

            //
            // Enable single app mode
            //
            EnableKiosk("com.apple.safari");

            System.Threading.Thread.Sleep(60000); //60 secs

            Console.WriteLine("Removing Kiosk mode...");

            //Remove Single App Mode (App Lock) - forcefully

            RemoveKiosk();

            Console.WriteLine("Done!");
        }



        static void EnableKiosk(string bundleid)
        {
            string result;

            result = cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "BundleId", bundleid);
            result = cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "Deploy", "true");
            result = cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "Inherit", "0");

            //Configure Single App Policies

            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "DisableTouch", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "DisableDeviceRotation", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "DisableVolumeButtons", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "DisableRingerSwitch", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "DisableSleepWakeButton", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "DisableAutoLock", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "EnableVoiceOver", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "EnableZoom", "false"); //enable/disable Zoom
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "EnableInvertColors", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "EnableAssistiveTouch", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "EnableSpeakSelection", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "EnableMonoAudio", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "VoiceOver", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "Zoom", "false"); //Zoom adjustment
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "InvertColors", "false");
            cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "AssistiveTouch", "false");

            //send policy to device
            result = cpservice.PingDevice(AuthObj, ManagedGroup);

        }

        static void RemoveKiosk()
        {
            string result;
            result = cpservice.AddPolicy(AuthObj, ManagedGroup, ProductId, "App Lock", "Deploy", "false");

            cpservice.PingDevice(AuthObj, ManagedGroup);
        }
    }
}
