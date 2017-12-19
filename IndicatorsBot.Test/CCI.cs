using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IndicatorsBot.Test
{
    [TestClass]
    public class CCI
    {
        Core.Indicators.CCI lista = new Core.Indicators.CCI();

        [TestInitialize]
        public void Initialize()
        {
            lista.Add(DateTime.Parse("2010/08/24"), (decimal)24.2013, (decimal)23.8534, (decimal)23.8932);
            lista.Add(DateTime.Parse("2010/08/25"), (decimal)24.0721, (decimal)23.7242, (decimal)23.9528);
            lista.Add(DateTime.Parse("2010/08/26"), (decimal)24.0423, (decimal)23.6447, (decimal)23.6745);
            lista.Add(DateTime.Parse("2010/08/27"), (decimal)23.8733, (decimal)23.3664, (decimal)23.7839);
            lista.Add(DateTime.Parse("2010/08/30"), (decimal)23.6745, (decimal)23.4559, (decimal)23.4956);
            lista.Add(DateTime.Parse("2010/08/31"), (decimal)23.5851, (decimal)23.1776, (decimal)23.3217);
            lista.Add(DateTime.Parse("2010/09/01"), (decimal)23.8037, (decimal)23.3962, (decimal)23.7540);
            lista.Add(DateTime.Parse("2010/09/02"), (decimal)23.8036, (decimal)23.5652, (decimal)23.7938);
            lista.Add(DateTime.Parse("2010/09/03"), (decimal)24.3007, (decimal)24.0522, (decimal)24.1417);
            lista.Add(DateTime.Parse("2010/09/07"), (decimal)24.1516, (decimal)23.7739, (decimal)23.8137);
            lista.Add(DateTime.Parse("2010/09/08"), (decimal)24.0522, (decimal)23.5950, (decimal)23.7839);
            lista.Add(DateTime.Parse("2010/09/09"), (decimal)24.0622, (decimal)23.8435, (decimal)23.8634);
            lista.Add(DateTime.Parse("2010/09/10"), (decimal)23.8833, (decimal)23.6447, (decimal)23.7044);
            lista.Add(DateTime.Parse("2010/09/13"), (decimal)25.1356, (decimal)23.9429, (decimal)24.9567);
            lista.Add(DateTime.Parse("2010/09/14"), (decimal)25.1952, (decimal)24.7380, (decimal)24.8771);
            lista.Add(DateTime.Parse("2010/09/15"), (decimal)25.0660, (decimal)24.7678, (decimal)24.9616);
            lista.Add(DateTime.Parse("2010/09/16"), (decimal)25.2151, (decimal)24.8970, (decimal)25.1753);
            lista.Add(DateTime.Parse("2010/09/17"), (decimal)25.3741, (decimal)24.9268, (decimal)25.0660);
            lista.Add(DateTime.Parse("2010/09/20"), (decimal)25.3642, (decimal)24.9567, (decimal)25.2747);
            lista.Add(DateTime.Parse("2010/09/21"), (decimal)25.2648, (decimal)24.9268, (decimal)24.9964);
            lista.Add(DateTime.Parse("2010/09/22"), (decimal)24.8175, (decimal)24.2112, (decimal)24.4597);
            lista.Add(DateTime.Parse("2010/09/23"), (decimal)24.4398, (decimal)24.2112, (decimal)24.2808);
            lista.Add(DateTime.Parse("2010/09/24"), (decimal)24.6485, (decimal)24.4299, (decimal)24.6237);
            lista.Add(DateTime.Parse("2010/09/27"), (decimal)24.8374, (decimal)24.4398, (decimal)24.5815);
            lista.Add(DateTime.Parse("2010/09/28"), (decimal)24.7479, (decimal)24.2013, (decimal)24.5268);
            lista.Add(DateTime.Parse("2010/09/29"), (decimal)24.5094, (decimal)24.2510, (decimal)24.3504);
            lista.Add(DateTime.Parse("2010/09/30"), (decimal)24.6784, (decimal)24.2112, (decimal)24.3404);
            lista.Add(DateTime.Parse("2010/10/01"), (decimal)24.6684, (decimal)24.1516, (decimal)24.2311);
            lista.Add(DateTime.Parse("2010/10/04"), (decimal)23.8435, (decimal)23.6348, (decimal)23.7640);
            lista.Add(DateTime.Parse("2010/10/05"), (decimal)24.3007, (decimal)23.7640, (decimal)24.2013);
        }

        [TestMethod]
        public void Test_That_Typical_Price_Is_Equals_To_Sum_of_Prices_Divided_by_3()
        {
            Assert.AreEqual((decimal)23.9826, lista[0].TypicalPrice);
            Assert.AreEqual((decimal)23.9164, lista[1].TypicalPrice);
            Assert.AreEqual((decimal)23.7872, lista[2].TypicalPrice);
            Assert.AreEqual((decimal)23.6745, lista[3].TypicalPrice);
            Assert.AreEqual((decimal)23.5420, lista[4].TypicalPrice);
            Assert.AreEqual((decimal)23.3615, lista[5].TypicalPrice);
            Assert.AreEqual((decimal)23.6513, lista[6].TypicalPrice);
            Assert.AreEqual((decimal)23.7209, lista[7].TypicalPrice);
            Assert.AreEqual((decimal)24.1649, lista[8].TypicalPrice);
            Assert.AreEqual((decimal)23.9131, lista[9].TypicalPrice);
            Assert.AreEqual((decimal)23.8104, lista[10].TypicalPrice);
            Assert.AreEqual((decimal)23.9230, lista[11].TypicalPrice);
            Assert.AreEqual((decimal)23.7441, lista[12].TypicalPrice);
            Assert.AreEqual((decimal)24.6784, lista[13].TypicalPrice);
            Assert.AreEqual((decimal)24.9368, lista[14].TypicalPrice);
            Assert.AreEqual((decimal)24.9318, lista[15].TypicalPrice);
            Assert.AreEqual((decimal)25.0958, lista[16].TypicalPrice);
            Assert.AreEqual((decimal)25.1223, lista[17].TypicalPrice);
            Assert.AreEqual((decimal)25.1985, lista[18].TypicalPrice);
            Assert.AreEqual((decimal)25.0627, lista[19].TypicalPrice);
            Assert.AreEqual((decimal)24.4961, lista[20].TypicalPrice);
            Assert.AreEqual((decimal)24.3106, lista[21].TypicalPrice);
            Assert.AreEqual((decimal)24.5674, lista[22].TypicalPrice);
            Assert.AreEqual((decimal)24.6196, lista[23].TypicalPrice);
            Assert.AreEqual((decimal)24.4920, lista[24].TypicalPrice);
            Assert.AreEqual((decimal)24.3703, lista[25].TypicalPrice);
            Assert.AreEqual((decimal)24.4100, lista[26].TypicalPrice);
            Assert.AreEqual((decimal)24.3504, lista[27].TypicalPrice);
            Assert.AreEqual((decimal)23.7474, lista[28].TypicalPrice);
            Assert.AreEqual((decimal)24.0887, lista[29].TypicalPrice);
        }

        [TestMethod]
        public void Test_That_SMA_is_Correct()
        {
            Assert.AreEqual(0, lista[0].SMA);
            Assert.AreEqual(0, lista[1].SMA);
            Assert.AreEqual(0, lista[2].SMA);
            Assert.AreEqual(0, lista[3].SMA);
            Assert.AreEqual(0, lista[4].SMA);
            Assert.AreEqual(0, lista[5].SMA);
            Assert.AreEqual(0, lista[6].SMA);
            Assert.AreEqual(0, lista[7].SMA);
            Assert.AreEqual(0, lista[8].SMA);
            Assert.AreEqual(0, lista[9].SMA);
            Assert.AreEqual(0, lista[10].SMA);
            Assert.AreEqual(0, lista[11].SMA);
            Assert.AreEqual(0, lista[12].SMA);
            Assert.AreEqual(0, lista[13].SMA);
            Assert.AreEqual(0, lista[14].SMA);
            Assert.AreEqual(0, lista[15].SMA);
            Assert.AreEqual(0, lista[16].SMA);
            Assert.AreEqual(0, lista[17].SMA);
            Assert.AreEqual(0, lista[18].SMA);
            Assert.AreEqual(24.2109, lista[19].SMA);
            Assert.AreEqual(24.2366, lista[20].SMA);
            Assert.AreEqual(24.2563, lista[21].SMA);
            Assert.AreEqual(24.2953, lista[22].SMA);
            Assert.AreEqual(24.3426, lista[23].SMA);
            Assert.AreEqual(24.3901, lista[24].SMA);
            Assert.AreEqual(24.4405, lista[25].SMA);
            Assert.AreEqual(24.4784, lista[26].SMA);
            Assert.AreEqual(24.5099, lista[27].SMA);
            Assert.AreEqual(24.4890, lista[28].SMA);
            Assert.AreEqual(24.4978, lista[29].SMA);
        }

        [TestMethod]
        public void Test_That_MAD_is_Correct()
        {
            Assert.AreEqual(0, lista[0].MAD);
            Assert.AreEqual(0, lista[1].MAD);
            Assert.AreEqual(0, lista[2].MAD);
            Assert.AreEqual(0, lista[3].MAD);
            Assert.AreEqual(0, lista[4].MAD);
            Assert.AreEqual(0, lista[5].MAD);
            Assert.AreEqual(0, lista[6].MAD);
            Assert.AreEqual(0, lista[7].MAD);
            Assert.AreEqual(0, lista[8].MAD);
            Assert.AreEqual(0, lista[9].MAD);
            Assert.AreEqual(0, lista[10].MAD);
            Assert.AreEqual(0, lista[11].MAD);
            Assert.AreEqual(0, lista[12].MAD);
            Assert.AreEqual(0, lista[13].MAD);
            Assert.AreEqual(0, lista[14].MAD);
            Assert.AreEqual(0, lista[15].MAD);
            Assert.AreEqual(0, lista[16].MAD);
            Assert.AreEqual(0, lista[17].MAD);
            Assert.AreEqual(0, lista[18].MAD);
            Assert.AreEqual(0.5550, lista[19].MAD);
            Assert.AreEqual(0.5630, lista[20].MAD);
            Assert.AreEqual(0.5526, lista[21].MAD);
            Assert.AreEqual(0.5447, lista[22].MAD);
            Assert.AreEqual(0.5284, lista[23].MAD);
            Assert.AreEqual(0.4911, lista[24].MAD);
            Assert.AreEqual(0.4356, lista[25].MAD);
            Assert.AreEqual(0.3939, lista[26].MAD);
            Assert.AreEqual(0.3624, lista[27].MAD);
            Assert.AreEqual(0.3822, lista[28].MAD);
            Assert.AreEqual(0.3733, lista[29].MAD);

        }

        [TestMethod]
        public void Test_That_CCI_is_Correct()
        {
            Assert.AreEqual(0, lista[0].CCI);
            Assert.AreEqual(0, lista[1].CCI);
            Assert.AreEqual(0, lista[2].CCI);
            Assert.AreEqual(0, lista[3].CCI);
            Assert.AreEqual(0, lista[4].CCI);
            Assert.AreEqual(0, lista[5].CCI);
            Assert.AreEqual(0, lista[6].CCI);
            Assert.AreEqual(0, lista[7].CCI);
            Assert.AreEqual(0, lista[8].CCI);
            Assert.AreEqual(0, lista[9].CCI);
            Assert.AreEqual(0, lista[10].CCI);
            Assert.AreEqual(0, lista[11].CCI);
            Assert.AreEqual(0, lista[12].CCI);
            Assert.AreEqual(0, lista[13].CCI);
            Assert.AreEqual(0, lista[14].CCI);
            Assert.AreEqual(0, lista[15].CCI);
            Assert.AreEqual(0, lista[16].CCI);
            Assert.AreEqual(0, lista[17].CCI);
            Assert.AreEqual(0, lista[18].CCI);
            Assert.AreEqual(102.3183, lista[19].CCI);
            Assert.AreEqual(30.7282, lista[20].CCI);
            Assert.AreEqual(6.5509, lista[21].CCI);
            Assert.AreEqual(33.3027, lista[22].CCI);
            Assert.AreEqual(34.9483, lista[23].CCI);
            Assert.AreEqual(13.8329, lista[24].CCI);
            Assert.AreEqual(-10.7438, lista[25].CCI);
            Assert.AreEqual(-11.5765, lista[26].CCI);
            Assert.AreEqual(-29.3414, lista[27].CCI);
            Assert.AreEqual(-129.3564, lista[28].CCI);
            Assert.AreEqual(-73.0601, lista[29].CCI);

        }

    }
}
