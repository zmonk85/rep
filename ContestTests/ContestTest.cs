using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CodeContest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContestTests
{
    [TestClass]
    public class ContestTest
    {
        private StreamReader _smallFile;
        [TestInitialize]
        public void TestSetup()
        {   
            var memStream = new MemoryStream();
            File.OpenRead("testing.in").CopyTo(memStream);

            _smallFile = new StreamReader(memStream);
            _smallFile.BaseStream.Position = 0;
        }

        [TestMethod]
        public void TestThatDataSetIsCorrect()
        {
            using(var input = _smallFile)
            using (var output = new StringWriter())
            {
                SmartShopper bs = new SmartShopper(input, output);                                          
                var time = MethodExtensions.TimeThisMethod(bs.GetResult, "Contest");

                Debug.WriteLine(string.Format("{0} \nStart: {1} \nEnd: {2} \nTotal Time: {3} milliseconds.", time.Item1,
                    time.Item2.ToString("hh:mm:ss.fffffff tt"),
                    time.Item2.AddTicks(time.Item3.Ticks).ToString("hh:mm:ss.fffffff tt"), time.Item3.TotalMilliseconds));

                File.WriteAllText("myresults.out", output.GetStringBuilder().ToString());
            }

            using (var results = File.OpenText("results.out"))
            using (var myResults = File.OpenText("myresults.out"))
            {
                string r = results.ReadToEnd().Trim();
                string mr = myResults.ReadToEnd().Trim();

                Assert.AreEqual(r, mr, "Unexpected results");

                Debug.WriteLine(mr);
            }
        }

        [TestMethod]
        public void TestLongDataSetIsCorrect()
        {
            var memStream = new MemoryStream();
            File.OpenRead("longtesting.in").CopyTo(memStream);

            StreamReader _largeFile = new StreamReader(memStream);
            _largeFile.BaseStream.Position = 0;                   

            using (var input = _largeFile)
            using (var output = new StringWriter())
            {
                SmartShopper bs = new SmartShopper(input, output);
                var time = MethodExtensions.TimeThisMethod(bs.GetResult, "Contest");

                Debug.WriteLine(string.Format("{0} \nStart: {1} \nEnd: {2} \nTotal Time: {3} milliseconds.", time.Item1,
                    time.Item2.ToString("hh:mm:ss.fffffff tt"),
                    time.Item2.AddTicks(time.Item3.Ticks).ToString("hh:mm:ss.fffffff tt"), time.Item3.TotalMilliseconds));

                File.WriteAllText("mylongresults.out", output.GetStringBuilder().ToString());
            }

            using (var results = File.OpenText("longresults.out"))
            using (var myResults = File.OpenText("mylongresults.out"))
            {
                string r = results.ReadToEnd().Trim();
                string mr = myResults.ReadToEnd().Trim();

                Assert.AreEqual(r, mr, "Unexpected results");

                Debug.WriteLine(mr);
            }
        }

        [TestMethod]
        public void TestLongDataSetDoesntTimeout()
        {
            var memStream = new MemoryStream();
            File.OpenRead("longtesting.in").CopyTo(memStream);

            StreamReader _largeFile = new StreamReader(memStream);
            _largeFile.BaseStream.Position = 0;

            using (var input = _largeFile)
            using (var output = new StringWriter())
            {
                SmartShopper bs = new SmartShopper(input, output);

                var task = Task.Run(() => bs.GetResult());

                Assert.IsTrue(GetTimeout(task, 10000).Result);

            }                        
        }

        private async Task<bool> GetTimeout(Task task, int i)
        {   
            return task == await Task.WhenAny(Task.Delay(30000), task);
        }

        [TestMethod]
        public void TestIntegrityOfStreamPriorToCallingGetResults()
        {
            var memStream = new MemoryStream();

            StreamReader _largeFile = new StreamReader(memStream);
            _largeFile.BaseStream.Position = 0;

            using (var input = _largeFile)
            using (var output = new StringWriter())
            {
                SmartShopper bs = new SmartShopper(input, output);
                Thread.Sleep(5000);
                File.OpenRead("testing.in").CopyTo(memStream);
                memStream.Position = 0;
                bs.GetResult();

                File.WriteAllText("myresults.out", output.GetStringBuilder().ToString());
            }

            using (var results = File.OpenText("results.out"))
            using (var myResults = File.OpenText("myresults.out"))
            {
                string r = results.ReadToEnd().Trim();
                string mr = myResults.ReadToEnd().Trim();

                Assert.AreEqual(r, mr, "Unexpected results");

                Debug.WriteLine(mr);
            }
        } 
    }
}
