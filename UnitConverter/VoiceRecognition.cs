/* 
 * Copyright (C) 2008 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Speech;
using Android.Views;
using Android.Widget;
using ConverterFramework;

namespace UnitConverter
{    
    [Activity(Label = "Voice Unit Converter", MainLauncher = true, Icon = "@drawable/icon",Theme = "@style/Theme.Background", ScreenOrientation = ScreenOrientation.Portrait)]
	[IntentFilter (new[] { Intent.ActionMain })]
	public class VoiceRecognition : Activity
	{
        private const int SHARE_DIALOG_LIST = 1;
        private const int MATCHES_LIST = 2;
        private const int HELP_DIALOG = 3;
		private const int VOICE_RECOGNITION_REQUEST_CODE = 1234;
        private List <Unit> resultUnits;       
        private IList<String> matches;
        private int count = 0;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			// Inflate our UI from its XML layout description.
			SetContentView (Resource.Layout.Main);
			// Get display items for later interaction
			Button speakButton = FindViewById<Button> (Resource.Id.btn_speak);		
			// Check to see if a recognition activity is present
			PackageManager pm = PackageManager;
			IList<ResolveInfo> activities = pm.QueryIntentActivities (new Intent (RecognizerIntent.ActionRecognizeSpeech), 0);
			if (activities.Count != 0)
				speakButton.Click += speakButton_Click;
			else {
				speakButton.Enabled = false;
				speakButton.Text = "Device Does not Support Speech Recognition";
			}
		  
            var btnShare = FindViewById<Button>(Resource.Id.btn_share);
            btnShare.Click += (sender, e) =>
                                  {
                                      Intent googlePlayIntent = new Intent(Intent.ActionView);
                                      googlePlayIntent.SetData(Android.Net.Uri.Parse("market://search?q=pub:Pocket Guru"));
                                      StartActivity(googlePlayIntent);
                                      //ShowDialog(SHARE_DIALOG_LIST);
                                  };

            var btnHelp = FindViewById<Button>(Resource.Id.btn_help);
            btnHelp.Click += (sender, e) =>
            { ShowDialog(HELP_DIALOG); };
		}
         


    
        private void TESTS()
        {
            string[] str =
                {
                  
              

                                                                       "dafaf asdfsfs",
                                                                   "1 ACRE to hectares",
                                                                   "2 HECTARE to square feet",
                                                                   "3 SQUARE FOOT to square yards",
                                                                   "4 SQUARE METER to square kilometers",
                                                                   "5 SQUARE KILOMETRE to square inch",
                                                                   "6 SQUARE INCH to square miles",
                                                                   "7 SQUARE YARD to acres",
                                                                   "8 SQUARE MILE to hectares",                                                                                                                                      
                                                                   
                                                                   "1 MILLIMETRE to centimetre",
                                                                   "2 CENTIMETRE to decimetre",
                                                                   "3 DECIMETRE to metre",
                                                                   "4 METRE to kilometre",
                                                                   "5 KILOMETER to foot",
                                                                   "6 FOOT to inch",
                                                                   "8 INCH to mile",
                                                                   "9 MILE to yards",
                                                                   "10 YARD to miles",
                                                                                                                                   
                                                                   "1 FAHRENHEIT to celsius",                                                               
                                                                   
                                                                   "1 DAY to hours",
                                                                   "2 HOUR to seconds",
                                                                   "3 SECOND to minutes",//-3 minutes
                                                                   "4 MINUTE to seconds", //-4seconds
                                                                   "5 YEAR to days",
                                                                   
                                                                   "1 CUBIC FOOT to cubic inches",//inchs
                                                                   "2 CUBIC INCH to cubic feet",//unknown
                                                                   "3 CUBIC MILE to cubic yards",
                                                                   "4 CUBIC YARD to cubic feet",
                                                                   "5 CUP to gallon",
                                                                   "6 GALLON to cup",
                                                                   "7 LITER to pint",
                                                                   "8 MILLILITER to litres",
                                                                   "9 PINT to quarts",
                                                                   "10 QUART to pints",
                                                                   "11 TABLESPOON to teaspoons",
                                                                   "12 TEASPOON to tablespoon",
                                                                                                                                      
                                                                   "1 MILLIGRAM to gram",
                                                                   "2 GRAM to milligram",
                                                                   "3 KILOGRAM to carat",
                                                                   "4 CARAT to pound",
                                                                   "5 POUND to carat",
                                                                   "6 TONNE to  gram",
                                                                   "7 OUNCE to gram",
                                                                   "dafaf asdfsfs"
                                                                         };


            matches = new List<string>();            
            matches.Add(str[count]);             
            parseString(matches);
            count++;
        }


        private void parseString(IList<string> matches)
        {
            UnitConversion converter = new UnitConversion();
            resultUnits = new List<Unit>();
            Unit resultUnit = null;

            foreach (string match in matches)
            {
                resultUnit = converter.GetUnits(match);
                if (resultUnit.isValid() == true)
                {
                    resultUnits.Add(resultUnit);
                    break;
                }
            }

            if (resultUnit.isValid() == false)
            {
                string output = "Please speak again\nExamples. \n'5 miles to feet\'\n'2 Pounds to Kilograms\'\n'4 Tablespoons to Teaspoons\'";
                Toast.MakeText(this, output, ToastLength.Long).Show();
            }
            else if (resultUnits.Count > 0)
            {                                            
                    ShowDialog(MATCHES_LIST);
                    
            }

        }
		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
            if (requestCode == VOICE_RECOGNITION_REQUEST_CODE && resultCode == Result.Ok) {				
                 matches=data.GetStringArrayListExtra (RecognizerIntent.ExtraResults);                                
                parseString(matches);            
            	}
            base.OnActivityResult(requestCode, resultCode, data);
		}

		private void speakButton_Click (object sender, EventArgs e)
		{
			View v = (View)sender;
			if (v.Id == Resource.Id.btn_speak)
				StartVoiceRecognitionActivity ();
		}

		private void StartVoiceRecognitionActivity ()
		{
			Intent intent = new Intent (RecognizerIntent.ActionRecognizeSpeech);
			intent.PutExtra (RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
			intent.PutExtra (RecognizerIntent.ExtraPrompt, "Eg. \"10 miles to feet\"");
			StartActivityForResult (intent, VOICE_RECOGNITION_REQUEST_CODE);
		}

        protected override Dialog OnCreateDialog(int id)
        {            
            switch (id)
            {
                case MATCHES_LIST:
                    {
                        string title = "";
                        List<string> matches = new List<string>();
                        foreach (Unit unit in resultUnits)
                        {
                            matches.Add(unit.resultString());
                        }            
                        var builder = new AlertDialog.Builder(this);
                        title = resultUnits[0].queryString() + " " + resultUnits[0].resultString();
                        builder.SetTitle(title);
                        builder.SetCancelable(true);
                        builder.SetPositiveButton("OK", delegate { });
                       // builder.SetItems(matches.ToArray(), ListClickedIgnore);                        
                        return builder.Create();                        
                        break;
                    }
                case SHARE_DIALOG_LIST:
                    {
                        var builder = new AlertDialog.Builder(this);
                        builder.SetTitle("Share");
                        builder.SetItems(Resource.Array.shareDialogList, ListClicked);
                        return builder.Create();
                        break;
                    }
                case HELP_DIALOG:
                    {
                        LayoutInflater inflater = (LayoutInflater)GetSystemService(Context.LayoutInflaterService);
                        View layout = inflater.Inflate(Resource.Layout.Help, (ViewGroup)FindViewById(Resource.Id.helpLayout));
                        AlertDialog.Builder builder = new AlertDialog.Builder(this).SetView(layout);
                        AlertDialog alertDialog = builder.Create();
                        alertDialog.Show();
                        break;                      
                    }                
            }
            return null;
        }   

        
 protected override void OnPrepareDialog(int id, Dialog dialog) 
  {
    base.OnPrepareDialog(id, dialog);


    switch (id)
    {
        case MATCHES_LIST:
            AlertDialog alertDialog = (AlertDialog)dialog;

            string title = "";
            title = resultUnits[0].queryString() + " " + resultUnits[0].resultString();
            alertDialog.SetTitle(title);
           
            //var child = (TextView)((AlertDialog)dialog).ListView.GetChildAt(0);
            //if (child!=null)
            //    child.SetText(resultUnits[0].resultString().ToCharArray(), 0, resultUnits[0].resultString().Length);

            break;
    }
  }



        /*private void getImperialDryLiquidUnits()
        {
            if (resultUnits.Count > 0)
            {
                if (resultUnits[0].fromUnit == Units.Ounce)
                {
                    Unit ounceUSFluidUnit = new Unit();
                    ounceUSFluidUnit.measurement = resultUnits[0].measurement;
                    ounceUSFluidUnit.toUnit = resultUnits[0].toUnit;
                    ounceUSFluidUnit.fromUnit = Units.OunceUsFluid;
                    resultUnits.Add(ounceUSFluidUnit);

                    Unit OunceImpFluid = new Unit();
                    OunceImpFluid.measurement = resultUnits[0].measurement;
                    OunceImpFluid.toUnit = resultUnits[0].toUnit;
                    OunceImpFluid.fromUnit = Units.OunceImpFluid;
                    resultUnits.Add(OunceImpFluid);
                }
                if (resultUnits[0].toUnit == Units.Ounce)
                {
                    Unit ounceUSFluidUnit = new Unit();
                    ounceUSFluidUnit.measurement = resultUnits[0].measurement;
                    ounceUSFluidUnit.fromUnit = resultUnits[0].fromUnit;
                    ounceUSFluidUnit.toUnit = Units.OunceUsFluid;
                    resultUnits.Add(ounceUSFluidUnit);

                    Unit OunceImpFluid = new Unit();
                    OunceImpFluid.measurement = resultUnits[0].measurement;
                    OunceImpFluid.fromUnit = resultUnits[0].fromUnit;
                    OunceImpFluid.toUnit = Units.OunceImpFluid;
                    resultUnits.Add(OunceImpFluid);
                }
                if (resultUnits[0].fromUnit == Units.GallonUs)
                {
                    Unit gallonImpUnit = new Unit();
                    gallonImpUnit.measurement = resultUnits[0].measurement;
                    gallonImpUnit.toUnit = resultUnits[0].toUnit;
                    gallonImpUnit.fromUnit = Units.GallonImp;
                    resultUnits.Add(gallonImpUnit);


                }
               if (resultUnits[0].toUnit == Units.GallonUs)
                {
                    Unit gallonImpUnit = new Unit();
                    gallonImpUnit.measurement = resultUnits[0].measurement;
                    gallonImpUnit.fromUnit = resultUnits[0].fromUnit;
                    gallonImpUnit.toUnit = Units.GallonImp;
                    resultUnits.Add(gallonImpUnit);
                }
               if (resultUnits[0].fromUnit == Units.PintImp)
                {
                    Unit pintUsDryUnit = new Unit();
                    pintUsDryUnit.measurement = resultUnits[0].measurement;
                    pintUsDryUnit.toUnit = resultUnits[0].toUnit;
                    pintUsDryUnit.fromUnit = Units.PintUsDry;
                    resultUnits.Add(pintUsDryUnit);

                    Unit pintUsLiquid = new Unit();
                    pintUsLiquid.measurement = resultUnits[0].measurement;
                    pintUsLiquid.toUnit = resultUnits[0].toUnit;
                    pintUsLiquid.fromUnit = Units.PintUsLiquid;
                    resultUnits.Add(pintUsLiquid);
                }
                if (resultUnits[0].toUnit == Units.PintImp)
                {
                    Unit pintUsDryUnit = new Unit();
                    pintUsDryUnit.measurement = resultUnits[0].measurement;
                    pintUsDryUnit.fromUnit = resultUnits[0].fromUnit;
                    pintUsDryUnit.toUnit = Units.PintUsDry;
                    resultUnits.Add(pintUsDryUnit);

                    Unit pintUsLiquid = new Unit();
                    pintUsLiquid.measurement = resultUnits[0].measurement;
                    pintUsLiquid.fromUnit = resultUnits[0].fromUnit;
                    pintUsLiquid.toUnit = Units.PintUsLiquid;
                    resultUnits.Add(pintUsLiquid);
                }
                if (resultUnits[0].fromUnit == Units.QuartImp)
                {
                    Unit quartUsDryUnit = new Unit();
                    quartUsDryUnit.measurement = resultUnits[0].measurement;
                    quartUsDryUnit.toUnit = resultUnits[0].toUnit;
                    quartUsDryUnit.fromUnit = Units.QuartUsDry;
                    resultUnits.Add(quartUsDryUnit);

                    Unit quartUsLiquidUnit = new Unit();
                    quartUsLiquidUnit.measurement = resultUnits[0].measurement;
                    quartUsLiquidUnit.toUnit = resultUnits[0].toUnit;
                    quartUsLiquidUnit.fromUnit = Units.QuartUsLiquid;
                    resultUnits.Add(quartUsLiquidUnit);
                }
                if (resultUnits[0].toUnit == Units.QuartImp)
                {
                    Unit quartUsDryUnit = new Unit();
                    quartUsDryUnit.measurement = resultUnits[0].measurement;
                    quartUsDryUnit.fromUnit = resultUnits[0].fromUnit;
                    quartUsDryUnit.toUnit = Units.QuartUsDry;
                    resultUnits.Add(quartUsDryUnit);

                    Unit quartUsLiquidUnit = new Unit();
                    quartUsLiquidUnit.measurement = resultUnits[0].measurement;
                    quartUsLiquidUnit.fromUnit = resultUnits[0].fromUnit;
                    quartUsLiquidUnit.toUnit = Units.QuartUsLiquid;
                    resultUnits.Add(quartUsLiquidUnit);
                }
            }
        }*/
                                    
        private void ListClicked(object sender, DialogClickEventArgs e)
        {
            
            var items = Resources.GetStringArray(Resource.Array.shareDialogList);
            var builder = new AlertDialog.Builder(this);
            builder.SetMessage(string.Format("You selected: {0} , {1}", (int)e.Which, items[(int)e.Which]));
            if ((int)e.Which == 0)
            {
                var smsUri = Android.Net.Uri.Parse("smsto:");
                Intent intent = new Intent(Intent.ActionView, smsUri);
                intent.PutExtra("sms_body", "Download this new Unit Converter App for Android, it works like Siri, convert Units with Voice commands. http://play.google.com/store/apps/details?id=ca.pocketguru.voiceunitconverter");                 
                StartActivity(intent);
                

            }

            else if ((int)e.Which == 1)
            {
                Intent i = new Intent(Intent.ActionSend);
                i.SetType("text/plain");
                i.PutExtra(Intent.ExtraSubject, "hey check out this new Voice Unit Converter app");
                i.PutExtra(Intent.ExtraText, "it works like Siri, convert Units with Voice commands http://play.google.com/store/apps/details?id=ca.pocketguru.voiceunitconverter");
                StartActivity(Intent.CreateChooser(i, "Send mail..."));
            }
            
            


        }
        
        private void ListClickedIgnore(object sender, DialogClickEventArgs e)
        {            
        }

	}
}
