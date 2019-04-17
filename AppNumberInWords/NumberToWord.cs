using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNumberInWords
{
    class NumberToWord
    {
        /// <summary>
        /// This function works only for ones digits. It is check all one's position value and save word
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        private static String Ones(String Number) //miavorneri durs berum
        {
            String name = "";
            int _Number = Convert.ToInt32(Number);
            switch(_Number)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two"; break;
                case 3:
                    name = "Three"; break;
                case 4:
                    name = "Four"; break;
                case 5:
                    name = "Five"; break;
                case 6:
                    name = "Six"; break;
                case 7:
                    name = "Seven"; break;
                case 8:
                    name = "Eight"; break;
                case 9:
                    name = "Nine"; break;

            }
            return name;
        }

        //Tasnavorneri durs berum
        private static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch(_Number)
            {
                case 10:
                    name = "Ten"; break;
                case 11:
                    name = "Eleven"; break;
                case 12:
                    name = "Twelve"; break;
                case 13:
                    name = "Thirteen"; break;
                case 14:
                    name = "Fourteen"; break;
                case 15:
                    name = "Fifteen"; break;
                case 16:
                    name = "Sixteen"; break;
                case 17:
                    name = "Seventeen"; break;
                case 18:
                    name = "Eigthteen"; break;
                case 19:
                    name = "Nineteen"; break;
                case 20:
                    name = "Twenty"; break;
                case 30:
                    name = "Thirty"; break;
                case 40:
                    name = "Fourty"; break;
                case 50:
                    name = "Fifty"; break;
                case 60:
                    name = "Sixty"; break;
                case 70:
                    name = "Seventy"; break;
                case 80:
                    name = "Eighty"; break;
                case 90:
                    name = "Ninety"; break;
                default:
                    if(_Number>0)
                    {
                        // if is not matching we will check the number is greater than zero and recursively calling this function again but before
                        // we removing the last number and concatenating zero to it ie. Passing this number to function again so that would get the result.
                        name = tens(Number.Substring(0, 1) + "0") + " " + Ones(Number.Substring(1));
                    }
                    break;

            }
            return name;
        }

        //A function which accepts a number up to 12 digits as a string and returns as a converted word string

        private static String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false; //test for 0xxx
                bool isDone = false; // test if already translated
                double dblAmt = (Convert.ToDouble(Number));
                //if((dblAmt>0) && number.StartsWith("0")
                if(dblAmt>0)
                {
                    //test for zero or digit zero in numberic
                    beginsZero = Number.StartsWith("0");
                    int numDigits = Number.Length;
                    int pos = 0;  //store digit grouping
                    String place = "";// digit grouping : hundreds thousand etc..
                    switch(numDigits)
                    {
                        case 1: //ones' range
                            word = Ones(Number);
                            isDone = true;
                            break;
                        case 2: //tens' range
                            word = tens(Number);
                            isDone = true; break;
                        case 3: //hundreds range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred "; break;
                        case 4: //thousand's 
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;    //4568 % 4=0+1=1 place=thousand
                            place = " Thousand ";
                            break;
                        case 7: //milions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10:
                        case 11:
                        case 12:
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion..
                        default:
                            isDone = true;
                            break;

                    }
                    if(!isDone) // if translation is not done continue Recursion comes in now
                    {
                        if(Number.Substring(0, pos)!="0" && Number.Substring(pos)!="0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }
                        // check for trailing zeros
                        // if(beginsZero) word=" and "+ word.Trim(); 
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim()))
                        word = "";

                }
            }
            catch { }
            return word.Trim();

        }


    }
}
