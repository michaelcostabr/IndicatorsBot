using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IndicatorsBot.Test
{
    [TestClass]
    public class BollingerBands
    {
        readonly Core.Indicators.BollingerBands lista = new Core.Indicators.BollingerBands();

        [TestInitialize]
        public void Initialize()
        {
            lista.Add(DateTime.Parse("2009/05/01"), (decimal)86.1557);
            lista.Add(DateTime.Parse("2009/05/04"), (decimal)89.0867);
            lista.Add(DateTime.Parse("2009/05/05"), (decimal)88.7829);
            lista.Add(DateTime.Parse("2009/05/06"), (decimal)90.3228);
            lista.Add(DateTime.Parse("2009/05/07"), (decimal)89.0671);
            lista.Add(DateTime.Parse("2009/05/08"), (decimal)91.1453);
            lista.Add(DateTime.Parse("2009/05/11"), (decimal)89.4397);
            lista.Add(DateTime.Parse("2009/05/12"), (decimal)89.1750);
            lista.Add(DateTime.Parse("2009/05/13"), (decimal)86.9302);
            lista.Add(DateTime.Parse("2009/05/14"), (decimal)87.6752);
            lista.Add(DateTime.Parse("2009/05/15"), (decimal)86.9596);
            lista.Add(DateTime.Parse("2009/05/18"), (decimal)89.4299);
            lista.Add(DateTime.Parse("2009/05/19"), (decimal)89.3221);
            lista.Add(DateTime.Parse("2009/05/20"), (decimal)88.7241);
            lista.Add(DateTime.Parse("2009/05/21"), (decimal)87.4497);
            lista.Add(DateTime.Parse("2009/05/22"), (decimal)87.2634);
            lista.Add(DateTime.Parse("2009/05/26"), (decimal)89.4985);
            lista.Add(DateTime.Parse("2009/05/27"), (decimal)87.9006);
            lista.Add(DateTime.Parse("2009/05/28"), (decimal)89.1260);
            lista.Add(DateTime.Parse("2009/05/29"), (decimal)90.7043);
            lista.Add(DateTime.Parse("2009/06/01"), (decimal)92.9001);
            lista.Add(DateTime.Parse("2009/06/02"), (decimal)92.9784);
            lista.Add(DateTime.Parse("2009/06/03"), (decimal)91.8021);
            lista.Add(DateTime.Parse("2009/06/04"), (decimal)92.6647);
            lista.Add(DateTime.Parse("2009/06/05"), (decimal)92.6843);
            lista.Add(DateTime.Parse("2009/06/08"), (decimal)92.3021);
            lista.Add(DateTime.Parse("2009/06/09"), (decimal)92.7725);
            lista.Add(DateTime.Parse("2009/06/10"), (decimal)92.5373);
            lista.Add(DateTime.Parse("2009/06/11"), (decimal)92.9490);
            lista.Add(DateTime.Parse("2009/06/12"), (decimal)93.2039);
            lista.Add(DateTime.Parse("2009/06/15"), (decimal)91.0669);
            lista.Add(DateTime.Parse("2009/06/16"), (decimal)89.8318);
            lista.Add(DateTime.Parse("2009/06/17"), (decimal)89.7435);
            lista.Add(DateTime.Parse("2009/06/18"), (decimal)90.3994);
            lista.Add(DateTime.Parse("2009/06/19"), (decimal)90.7387);
            lista.Add(DateTime.Parse("2009/06/22"), (decimal)88.0177);
            lista.Add(DateTime.Parse("2009/06/23"), (decimal)88.0867);
            lista.Add(DateTime.Parse("2009/06/24"), (decimal)88.8439);
            lista.Add(DateTime.Parse("2009/06/25"), (decimal)90.7781);
            lista.Add(DateTime.Parse("2009/06/26"), (decimal)90.5416);
            lista.Add(DateTime.Parse("2009/06/29"), (decimal)91.3894);
            lista.Add(DateTime.Parse("2009/06/30"), (decimal)90.6500);
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
            Assert.AreEqual(0, lista[15].SMA);
            Assert.AreEqual(0, lista[17].SMA);
            Assert.AreEqual(0, lista[18].SMA);
            Assert.AreEqual(88.7079, lista[19].SMA);
            Assert.AreEqual(89.0452, lista[20].SMA);
            Assert.AreEqual(89.2397, lista[21].SMA);
            Assert.AreEqual(89.3907, lista[22].SMA);
            Assert.AreEqual(89.5078, lista[23].SMA);
            Assert.AreEqual(89.6887, lista[24].SMA);
            Assert.AreEqual(89.7465, lista[25].SMA);
            Assert.AreEqual(89.9131, lista[26].SMA);
            Assert.AreEqual(90.0813, lista[27].SMA);
            Assert.AreEqual(90.3822, lista[28].SMA);
            Assert.AreEqual(90.6586, lista[29].SMA);
            Assert.AreEqual(90.8640, lista[30].SMA);
            Assert.AreEqual(90.8841, lista[31].SMA);
            Assert.AreEqual(90.9052, lista[32].SMA);
            Assert.AreEqual(90.9889, lista[33].SMA);
            Assert.AreEqual(91.1534, lista[34].SMA);
            Assert.AreEqual(91.1911, lista[35].SMA);
            Assert.AreEqual(91.1205, lista[36].SMA);
            Assert.AreEqual(91.1677, lista[37].SMA);
            Assert.AreEqual(91.2503, lista[38].SMA);
            Assert.AreEqual(91.2421, lista[39].SMA);
            Assert.AreEqual(91.1666, lista[40].SMA);
            Assert.AreEqual(91.0502, lista[41].SMA);
        }

        [TestMethod]
        public void Test_That_SD_is_Correct()
        {
            Assert.AreEqual(0, lista[0].SD);
            Assert.AreEqual(0, lista[1].SD);
            Assert.AreEqual(0, lista[2].SD);
            Assert.AreEqual(0, lista[3].SD);
            Assert.AreEqual(0, lista[4].SD);
            Assert.AreEqual(0, lista[5].SD);
            Assert.AreEqual(0, lista[6].SD);
            Assert.AreEqual(0, lista[7].SD);
            Assert.AreEqual(0, lista[8].SD);
            Assert.AreEqual(0, lista[9].SD);
            Assert.AreEqual(0, lista[10].SD);
            Assert.AreEqual(0, lista[11].SD);
            Assert.AreEqual(0, lista[12].SD);
            Assert.AreEqual(0, lista[13].SD);
            Assert.AreEqual(0, lista[14].SD);
            Assert.AreEqual(0, lista[15].SD);
            Assert.AreEqual(0, lista[16].SD);
            Assert.AreEqual(0, lista[17].SD);
            Assert.AreEqual(0, lista[18].SD);
            Assert.AreEqual(1.2920, lista[19].SD);
            Assert.AreEqual(1.4521, lista[20].SD);
            Assert.AreEqual(1.6864, lista[21].SD);
            Assert.AreEqual(1.7717, lista[22].SD);
            Assert.AreEqual(1.9021, lista[23].SD);
            Assert.AreEqual(2.0199, lista[24].SD);
            Assert.AreEqual(2.0765, lista[25].SD);
            Assert.AreEqual(2.1766, lista[26].SD);
            Assert.AreEqual(2.2419, lista[27].SD);
            Assert.AreEqual(2.2024, lista[28].SD);
            Assert.AreEqual(2.1922, lista[29].SD);
            Assert.AreEqual(2.0218, lista[30].SD);
            Assert.AreEqual(2.0094, lista[31].SD);
            Assert.AreEqual(1.9951, lista[32].SD);
            Assert.AreEqual(1.9360, lista[33].SD);
            Assert.AreEqual(1.7601, lista[34].SD);
            Assert.AreEqual(1.6828, lista[35].SD);
            Assert.AreEqual(1.7791, lista[36].SD);
            Assert.AreEqual(1.7041, lista[37].SD);
            Assert.AreEqual(1.6420, lista[38].SD);
            Assert.AreEqual(1.6451, lista[39].SD);
            Assert.AreEqual(1.6013, lista[40].SD);
            Assert.AreEqual(1.5492, lista[41].SD);
        }

        [TestMethod]
        public void Test_That_UpperBand_is_Correct()
        {
            Assert.AreEqual(0, lista[0].UpperBandSMA);
            Assert.AreEqual(0, lista[1].UpperBandSMA);
            Assert.AreEqual(0, lista[2].UpperBandSMA);
            Assert.AreEqual(0, lista[3].UpperBandSMA);
            Assert.AreEqual(0, lista[4].UpperBandSMA);
            Assert.AreEqual(0, lista[5].UpperBandSMA);
            Assert.AreEqual(0, lista[6].UpperBandSMA);
            Assert.AreEqual(0, lista[7].UpperBandSMA);
            Assert.AreEqual(0, lista[8].UpperBandSMA);
            Assert.AreEqual(0, lista[9].UpperBandSMA);
            Assert.AreEqual(0, lista[10].UpperBandSMA);
            Assert.AreEqual(0, lista[11].UpperBandSMA);
            Assert.AreEqual(0, lista[12].UpperBandSMA);
            Assert.AreEqual(0, lista[13].UpperBandSMA);
            Assert.AreEqual(0, lista[14].UpperBandSMA);
            Assert.AreEqual(0, lista[15].UpperBandSMA);
            Assert.AreEqual(0, lista[16].UpperBandSMA);
            Assert.AreEqual(0, lista[17].UpperBandSMA);
            Assert.AreEqual(0, lista[18].UpperBandSMA);
            Assert.AreEqual(91.29, lista[19].UpperBandSMA);
            Assert.AreEqual(91.95, lista[20].UpperBandSMA);
            Assert.AreEqual(92.61, lista[21].UpperBandSMA);
            Assert.AreEqual(92.93, lista[22].UpperBandSMA);
            Assert.AreEqual(93.31, lista[23].UpperBandSMA);
            Assert.AreEqual(93.73, lista[24].UpperBandSMA);
            Assert.AreEqual(93.90, lista[25].UpperBandSMA);
            Assert.AreEqual(94.27, lista[26].UpperBandSMA);
            Assert.AreEqual(94.57, lista[27].UpperBandSMA);
            Assert.AreEqual(94.79, lista[28].UpperBandSMA);
            Assert.AreEqual(95.04, lista[29].UpperBandSMA);
            Assert.AreEqual(94.91, lista[30].UpperBandSMA);
            Assert.AreEqual(94.90, lista[31].UpperBandSMA);
            Assert.AreEqual(94.90, lista[32].UpperBandSMA);
            Assert.AreEqual(94.86, lista[33].UpperBandSMA);
            Assert.AreEqual(94.67, lista[34].UpperBandSMA);
            Assert.AreEqual(94.56, lista[35].UpperBandSMA);
            Assert.AreEqual(94.68, lista[36].UpperBandSMA);
            Assert.AreEqual(94.58, lista[37].UpperBandSMA);
            Assert.AreEqual(94.53, lista[38].UpperBandSMA);
            Assert.AreEqual(94.53, lista[39].UpperBandSMA);
            Assert.AreEqual(94.37, lista[40].UpperBandSMA);
            Assert.AreEqual(94.15, lista[41].UpperBandSMA);

        }

        [TestMethod]
        public void Test_That_LowerBand_is_Correct()
        {
            Assert.AreEqual(0, lista[0].LowerBandSMA);
            Assert.AreEqual(0, lista[1].LowerBandSMA);
            Assert.AreEqual(0, lista[2].LowerBandSMA);
            Assert.AreEqual(0, lista[3].LowerBandSMA);
            Assert.AreEqual(0, lista[4].LowerBandSMA);
            Assert.AreEqual(0, lista[5].LowerBandSMA);
            Assert.AreEqual(0, lista[6].LowerBandSMA);
            Assert.AreEqual(0, lista[7].LowerBandSMA);
            Assert.AreEqual(0, lista[8].LowerBandSMA);
            Assert.AreEqual(0, lista[9].LowerBandSMA);
            Assert.AreEqual(0, lista[10].LowerBandSMA);
            Assert.AreEqual(0, lista[11].LowerBandSMA);
            Assert.AreEqual(0, lista[12].LowerBandSMA);
            Assert.AreEqual(0, lista[13].LowerBandSMA);
            Assert.AreEqual(0, lista[14].LowerBandSMA);
            Assert.AreEqual(0, lista[15].LowerBandSMA);
            Assert.AreEqual(0, lista[16].LowerBandSMA);
            Assert.AreEqual(0, lista[17].LowerBandSMA);
            Assert.AreEqual(0, lista[18].LowerBandSMA);
            Assert.AreEqual(86.12, lista[19].LowerBandSMA);
            Assert.AreEqual(86.14, lista[20].LowerBandSMA);
            Assert.AreEqual(85.87, lista[21].LowerBandSMA);
            Assert.AreEqual(85.85, lista[22].LowerBandSMA);
            Assert.AreEqual(85.70, lista[23].LowerBandSMA);
            Assert.AreEqual(85.65, lista[24].LowerBandSMA);
            Assert.AreEqual(85.59, lista[25].LowerBandSMA);
            Assert.AreEqual(85.56, lista[26].LowerBandSMA);
            Assert.AreEqual(85.60, lista[27].LowerBandSMA);
            Assert.AreEqual(85.98, lista[28].LowerBandSMA);
            Assert.AreEqual(86.27, lista[29].LowerBandSMA);
            Assert.AreEqual(86.82, lista[30].LowerBandSMA);
            Assert.AreEqual(86.87, lista[31].LowerBandSMA);
            Assert.AreEqual(86.92, lista[32].LowerBandSMA);
            Assert.AreEqual(87.12, lista[33].LowerBandSMA);
            Assert.AreEqual(87.63, lista[34].LowerBandSMA);
            Assert.AreEqual(87.83, lista[35].LowerBandSMA);
            Assert.AreEqual(87.56, lista[36].LowerBandSMA);
            Assert.AreEqual(87.76, lista[37].LowerBandSMA);
            Assert.AreEqual(87.97, lista[38].LowerBandSMA);
            Assert.AreEqual(87.95, lista[39].LowerBandSMA);
            Assert.AreEqual(87.96, lista[40].LowerBandSMA);
            Assert.AreEqual(87.95, lista[41].LowerBandSMA);

        }

        [TestMethod]
        public void Test_That_Bandwidth_is_Correct()
        {
            Assert.AreEqual(0, lista[0].BandWidth);
            Assert.AreEqual(0, lista[1].BandWidth);
            Assert.AreEqual(0, lista[2].BandWidth);
            Assert.AreEqual(0, lista[3].BandWidth);
            Assert.AreEqual(0, lista[4].BandWidth);
            Assert.AreEqual(0, lista[5].BandWidth);
            Assert.AreEqual(0, lista[6].BandWidth);
            Assert.AreEqual(0, lista[7].BandWidth);
            Assert.AreEqual(0, lista[8].BandWidth);
            Assert.AreEqual(0, lista[9].BandWidth);
            Assert.AreEqual(0, lista[10].BandWidth);
            Assert.AreEqual(0, lista[11].BandWidth);
            Assert.AreEqual(0, lista[12].BandWidth);
            Assert.AreEqual(0, lista[13].BandWidth);
            Assert.AreEqual(0, lista[14].BandWidth);
            Assert.AreEqual(0, lista[15].BandWidth);
            Assert.AreEqual(0, lista[16].BandWidth);
            Assert.AreEqual(0, lista[17].BandWidth);
            Assert.AreEqual(0, lista[18].BandWidth);
            Assert.AreEqual(5.17, lista[19].BandWidth);
            Assert.AreEqual(5.81, lista[20].BandWidth);
            Assert.AreEqual(6.74, lista[21].BandWidth);
            Assert.AreEqual(7.08, lista[22].BandWidth);
            Assert.AreEqual(7.61, lista[23].BandWidth);
            Assert.AreEqual(8.08, lista[24].BandWidth);
            Assert.AreEqual(8.31, lista[25].BandWidth);
            Assert.AreEqual(8.71, lista[26].BandWidth);
            Assert.AreEqual(8.97, lista[27].BandWidth);
            Assert.AreEqual(8.81, lista[28].BandWidth);
            Assert.AreEqual(8.77, lista[29].BandWidth);
            Assert.AreEqual(8.09, lista[30].BandWidth);
            Assert.AreEqual(8.03, lista[31].BandWidth);
            Assert.AreEqual(7.98, lista[32].BandWidth);
            Assert.AreEqual(7.74, lista[33].BandWidth);
            Assert.AreEqual(7.04, lista[34].BandWidth);
            Assert.AreEqual(6.73, lista[35].BandWidth);
            Assert.AreEqual(7.12, lista[36].BandWidth);
            Assert.AreEqual(6.82, lista[37].BandWidth);
            Assert.AreEqual(6.56, lista[38].BandWidth);
            Assert.AreEqual(6.58, lista[39].BandWidth);
            Assert.AreEqual(6.41, lista[40].BandWidth);
            Assert.AreEqual(6.20, lista[41].BandWidth);

        }
    }
}
