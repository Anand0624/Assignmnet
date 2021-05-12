using CodeAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;

namespace CodeAssignment.Controllers
{
    [Route("Assignmnet")]
    public class TestController : Controller
    {
        

        /// <summary>
        /// Method to total all the values that are even numbers from given request.
        /// </summary>
        /// <param name="intergarVal">Add multiple values in array</param>
        /// <returns>Returns total of even numbers from given array</returns>
        [HttpGet]
        [Route("EvenNumberTotal")]
        public ActionResult<string> CalculateIntegarArray([FromQuery] int[] intergarVal)
        {
            Int64 total = intergarVal.Where(i => i % 2 == 0).Sum(i => (long)i);
            string totalMessage = "Total Of Even Numbers in Array is : " +total;
            return Ok(totalMessage);
        }

        /// <summary>
        /// Method to prints numbers from 1 to 100 for multiples of 3 and 5 number will return  “valar” and “morghulis” and for both will return “valar morghulis”
        /// </summary>
       
        [HttpGet]
        [Route("1To100Print")]
        public ActionResult<List<string>> Calculate1To100()
        {
            List<string> Numbers = new List<string>();
            for (int i = 1; i < 101; i++)
            {
                if (i % 3 == 0 & i % 5 == 0)
                Numbers.Add("valar morghulis");
                else if (i % 3 == 0)
                Numbers.Add("valar");
                else if (i % 5 == 0)
                    Numbers.Add("morghulis");
                else
                    Numbers.Add(i.ToString());
            }
            return Ok(Numbers);
        }

        /// <summary>
        /// Method to swap two numbers without temporary number
        /// </summary>
        /// <param name="number1">First number for swap</param>
        /// <param name="number2">Second number for swap</param>
        /// <returns>Returns swaped numbers of given number</returns>
        [HttpGet]
        [Route("SwapTwoNumbers")]
        public ActionResult<string> SwapTwoNumbers([FromQuery] [Required] Int64 number1, [Required] Int64 number2)
        {
            number1 = number1 + number2;
            number2 = number1 - number2;
            number1 = number1 - number2;
            string response = "Values after swaping numbers is Number1="+number1+" and Number2="+number2+"";
            return Ok(response);
        }

        /// <summary>
        /// Method to return fibonacci series of given nuber
        /// </summary>
        /// <param name="number">number for fibonacciseries</param>
        /// <returns>Returns Fibonacci Series number</returns>
        [HttpGet]
        [Route("FibonacciNumber")]
        public ActionResult<string> FibonacciNumber([FromQuery][Required] Int64 number)
        {
            int x = 0, y = 1, z = 0, i;
            for (i = 1; i <= number; i++)
            {
                z = x + y;
                x = y;
                y = z;
            }
            string response = string.Format("the {0}th term of Fibonacci Series is {1} ",number,z);
            return Ok(response);
        }

        /// <summary>
        /// Method to calculate CircumferenceOfCircle
        /// </summary>
        /// <returns>CircumferenceOfCircle</returns>
        [HttpGet]
        [Route("CircumferenceOfCircle")]
        public ActionResult<string> CircumferenceOfCircle()
        {
            Circle cir = new Circle();
            double circ = cir.Calculate((radius) => 2 * Math.PI * radius);
            return Ok("Output : "+circ);
        }

        /// <summary>
        /// Method to calculate Power Of Number
        /// </summary>
        /// <param name="number">number for calculate power</param>
        /// <param name="power">power of number</param>
        /// <returns>Returns power of given number</returns>
        [HttpGet]
        [Route("Calculatepowerofnumber")]
        public ActionResult<string> Calculatepowerofnumber([FromQuery][Required]  Int64 number, [Required] Int64 power)
        {
            long res = this.power(number, power);
            string response = string.Format("Power of {0} number is {1}", number, res);
            return Ok(response);
        }

        /// <summary>
        /// Method to return Enum values
        /// </summary>
        /// <returns>Returns Enum values </returns>
        [HttpGet]
        [Route("EnumValues")]
        public ActionResult<List<String>> EnumValues()
        {
            List<string> Enumvalues = new List<string>();
            Array values = Enum.GetValues(typeof(colors));
            foreach (colors val in values)
            {
                Enumvalues.Add(string.Format("{0}:{1}", Enum.GetName(typeof(colors), val), val));
            }
            return Ok(Enumvalues);
        }

        /// <summary>
        /// Method to caculate AreaOfRectangle And Square with using over loaded function
        /// </summary>
        /// <param name="side">side for calculate area of square</param>
        /// <param name="length">length for calculate area of rectangel</param>
        /// <param name="breadth">breadth for calculate area of rectangel</param>
        /// <returns>Return Area of Square </returns> 
        /// <returns>Return Area of Rectangle </returns> 

        [HttpGet]
        [Route("AreaOfRectangleAndSquare")]
        public ActionResult<string> AreaOfRectangleAndSquare([FromQuery][Required] float side,[Required] float length, [Required] float breadth)
        {
            float areaOfSquare = Area(side);
            float areaOfRectangle = Area(length, breadth);
            string response = string.Format("Area of Square is {0} And  ", areaOfSquare);
            response+= string.Format("Area of Rectangle is {0}", areaOfRectangle);
            return Ok(response);
        }

        /// <summary>
        /// Method to get best batting momentum
        /// </summary>
        /// <returns>Returns swaped numbers of given number</returns>
        [HttpGet]
        [Route("GetBestBatsmanMoment")]
        [HttpGet]
        public ActionResult<Batsman> batsman()
        {
            string paylod = "[{\"Batsmanname\":\"ViratKholi\",\"RunsScored\":50,\"StrikeRate\":78.30},{\"Batsmanname\":\"M.S.Dhoni\",\"RunsScored\":61,\"StrikeRate\":58.90},{\"Batsmanname\":\"RohitSharma\",\"RunsScored\":13,\"StrikeRate\":124.0}]";
            List<Batsman> batsmanList = JsonSerializer.Deserialize<List<Batsman>>(paylod);
            var maxAverageRate = batsmanList.Max(r => r.RunsScored * r.StrikeRate);
            var batsman = batsmanList.Where(r => (r.RunsScored * r.StrikeRate) == maxAverageRate).FirstOrDefault();
            return Ok(batsman);
        }

        /// <summary>
        /// Method to get best batting momentum
        /// </summary>
        /// <returns>Returns playes IsRetired flag updated data </returns> 
        [HttpGet]
        [Route("UpdatePlayersRetirement")]
        [HttpGet]
        public ActionResult<List<PlayersList>> Players()
        {
            string paylod = "[{\"PlayerName\":\"Virat Kholi\",\"IsRetired\":1},{\"PlayerName\":\"M.S. Dhoni\",\"IsRetired\":1},{\"PlayerName\":\"Hardik Pandya\",\"IsRetired\":1},{\"PlayerName\":\"Rohit Sharma\",\"IsRetired\":1},{\"PlayerName\":\"Sachin Tendulkar\",\"IsRetired\":0},{\"PlayerName\":\"Rahul Dravid\",\"IsRetired\":0},{\"PlayerName\":\"Sourav Ganguly\",\"IsRetired\":0},{\"PlayerName\":\"VVS Laxman\",\"IsRetired\":0}]";
            List<PlayersList> playersList = JsonSerializer.Deserialize<List<PlayersList>>(paylod);
            var data = playersList.Select(p => new PlayersList {PlayerName=p.PlayerName, IsRetired=p.IsRetired == 1 ? 0 : p.IsRetired == 0 ? 1 : 0  }).ToList();
            return Ok(data);
        }

        /// <summary>
        /// Method to get return string json to object
        /// </summary>
        /// <returns>Returns json object </returns>
        [HttpGet]
        [Route("JsonToObject")]
        [HttpGet]
        public ActionResult<TeamDetails> JsonObject()
        {
            string paylod = "{\"Name_Full\":\"SunrisersHyderabad\",\"Name_Short\":\"SRH\",\"Players\":{\"5380\":{\"Position\":\"1\",\"Name_Full\":\"DavidWarner\",\"IsCaptain\":true},\"3722\":{\"Position\":\"2\",\"Name_Full\":\"ShikharDhawan\",\"IsCaptain\":false}}}";
            var teamDetails = JsonSerializer.Deserialize<TeamDetails>(paylod);
            teamDetails.Players = JsonSerializer.Deserialize<Dictionary<string, PlayerDetails>>(teamDetails.Players.ToString());
            return Ok(teamDetails);
        }

        /// <summary>
        /// Method to get return WicketTakingPlayer details
        /// </summary>
        /// <returns>Returns WicketTakingPlayer details </returns>
        [HttpGet]
        [Route("WicketTakingPlayer")]
        [HttpGet]
        public ActionResult<List<PlayerswicketData>> WicketTakingPlayer()
        {
            string playersPaylod = "[{\"PlayerId\":21,\"PlayerName\":\"Y.Chahal\"},{\"PlayerId\":22,\"PlayerName\":\"BhuvneshwarKumar\"},{\"PlayerId\":23,\"PlayerName\":\"JaspritBumrah\"},{\"PlayerId\":24,\"PlayerName\":\"HardikPandya\"},{\"PlayerId\":25,\"PlayerName\":\"RavindraJadeja\"},{\"PlayerId\":26,\"PlayerName\":\"MohammedShami\"}]";
            string wicketsPaylod = "[{\"PlayerId\":21,\"Wickets\":2},{\"PlayerId\":22,\"Wickets\":1},{\"PlayerId\":23,\"Wickets\":3},{\"PlayerId\":26,\"Wickets\":1}]";
            List<Players> playerDetails = JsonSerializer.Deserialize<List<Players>>(playersPaylod);
            List<Playerswicket> wicketDetails = JsonSerializer.Deserialize<List<Playerswicket>>(wicketsPaylod);
            var playerwicketDetails = (from player in playerDetails
                      join wicket in wicketDetails on player.PlayerId equals wicket.PlayerId
                      select new PlayerswicketData { PlayerId=player.PlayerId, PlayerName=player.PlayerName,Wickets=wicket.Wickets }).ToList();
            return Ok(playerwicketDetails);
        }

        /// <summary>
        ///  Circle class
        /// </summary>
        public sealed class Circle
        {
            private double radius = 5;
            public double Calculate(Func<double, double> op)
            {
                return op(radius);
            }
        }

        /// <summary>
        /// function to calculate power of number
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        Int64 power(Int64 n, Int64 p)
        {
            if (p != 0)
            {
                return (n * power(n, p - 1));
            }
            return 1;
        }

        /// <summary>
        /// Enum 
        /// </summary>
        public enum colors
        {
            red,
            blue,
            green,
            yellow
        }

        /// <summary>
        /// function to calculate area
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        float Area(float side)
        {
            float squarearea = side * side;
            return squarearea;
        }

        /// <summary>
        /// function to calculate area
        /// </summary>
        /// <param name="length"></param>
        /// <param name="breadth"></param>
        /// <returns></returns>
        float Area(float length, float breadth)
        {
            float rectangle = length * breadth;
            return rectangle;
        }
    }
}
