using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IndicatorsBot.Test
{
    [TestClass]
    public class RSI
    {
        readonly Core.Indicators.RSI lista = new Core.Indicators.RSI();

        [TestInitialize]
        public void Initialize()
        {
            lista.Add(DateTime.Parse("2009/12/14"), (decimal)44.33890000);
            lista.Add(DateTime.Parse("2009/12/15"), (decimal)44.09020000);
            lista.Add(DateTime.Parse("2009/12/16"), (decimal)44.14970000);
            lista.Add(DateTime.Parse("2009/12/17"), (decimal)43.61240000);
            lista.Add(DateTime.Parse("2009/12/18"), (decimal)44.32780000);
            lista.Add(DateTime.Parse("2009/12/21"), (decimal)44.82640000);
            lista.Add(DateTime.Parse("2009/12/22"), (decimal)45.09550000);
            lista.Add(DateTime.Parse("2009/12/23"), (decimal)45.42450000);
            lista.Add(DateTime.Parse("2009/12/24"), (decimal)45.84330000);
            lista.Add(DateTime.Parse("2009/12/28"), (decimal)46.08260000);
            lista.Add(DateTime.Parse("2009/12/29"), (decimal)45.89310000);
            lista.Add(DateTime.Parse("2009/12/30"), (decimal)46.03280000);
            lista.Add(DateTime.Parse("2009/12/31"), (decimal)45.61400000);
            lista.Add(DateTime.Parse("2010/01/04"), (decimal)46.28200000);
            lista.Add(DateTime.Parse("2010/01/05"), (decimal)46.28200000);
            lista.Add(DateTime.Parse("2010/01/06"), (decimal)46.00280000);
            lista.Add(DateTime.Parse("2010/01/07"), (decimal)46.03280000);
            lista.Add(DateTime.Parse("2010/01/08"), (decimal)46.41160000);
            lista.Add(DateTime.Parse("2010/01/11"), (decimal)46.22220000);
            lista.Add(DateTime.Parse("2010/01/12"), (decimal)45.64390000);
            lista.Add(DateTime.Parse("2010/01/13"), (decimal)46.21220000);
            lista.Add(DateTime.Parse("2010/01/14"), (decimal)46.25210000);
            lista.Add(DateTime.Parse("2010/01/15"), (decimal)45.71370000);
            lista.Add(DateTime.Parse("2010/01/19"), (decimal)46.45150000);
            lista.Add(DateTime.Parse("2010/01/20"), (decimal)45.78350000);
            lista.Add(DateTime.Parse("2010/01/21"), (decimal)45.35480000);
            lista.Add(DateTime.Parse("2010/01/22"), (decimal)44.02880000);
            lista.Add(DateTime.Parse("2010/01/25"), (decimal)44.17830000);
            lista.Add(DateTime.Parse("2010/01/26"), (decimal)44.21810000);
            lista.Add(DateTime.Parse("2010/01/27"), (decimal)44.56720000);
            lista.Add(DateTime.Parse("2010/01/28"), (decimal)43.42050000);
            lista.Add(DateTime.Parse("2010/01/29"), (decimal)42.66280000);
            lista.Add(DateTime.Parse("2010/02/01"), (decimal)43.13140000);
            lista.Add(DateTime.Parse("2010/02/02"), (decimal)25);
        }

        [TestMethod]
        public void Test_That_Change_Is_Equals_To_Current_Minus_Last()
        {
            Assert.AreEqual(0, lista[0].Change);
            Assert.AreEqual((decimal)-0.24870000, lista[1].Change);
            Assert.AreEqual((decimal)0.05950000, lista[2].Change);
            Assert.AreEqual((decimal)-0.53730000, lista[3].Change);
            Assert.AreEqual((decimal)0.71540000, lista[4].Change);
            Assert.AreEqual((decimal)0.49860000, lista[5].Change);
            Assert.AreEqual((decimal)0.26910000, lista[6].Change);
            Assert.AreEqual((decimal)0.32900000, lista[7].Change);
            Assert.AreEqual((decimal)0.41880000, lista[8].Change);
            Assert.AreEqual((decimal)0.23930000, lista[9].Change);
            Assert.AreEqual((decimal)-0.18950000, lista[10].Change);
            Assert.AreEqual((decimal)0.13970000, lista[11].Change);
            Assert.AreEqual((decimal)-0.41880000, lista[12].Change);
            Assert.AreEqual((decimal)0.66800000, lista[13].Change);
            Assert.AreEqual((decimal)0, lista[14].Change);
            Assert.AreEqual((decimal)-0.27920000, lista[15].Change);
            Assert.AreEqual((decimal)0.03000000, lista[16].Change);
            Assert.AreEqual((decimal)0.37880000, lista[17].Change);
            Assert.AreEqual((decimal)-0.18940000, lista[18].Change);
            Assert.AreEqual((decimal)-0.57830000, lista[19].Change);
            Assert.AreEqual((decimal)0.56830000, lista[20].Change);
            Assert.AreEqual((decimal)0.03990000, lista[21].Change);
            Assert.AreEqual((decimal)-0.53840000, lista[22].Change);
            Assert.AreEqual((decimal)0.73780000, lista[23].Change);
            Assert.AreEqual((decimal)-0.66800000, lista[24].Change);
            Assert.AreEqual((decimal)-0.42870000, lista[25].Change);
            Assert.AreEqual((decimal)-1.32600000, lista[26].Change);
            Assert.AreEqual((decimal)0.14950000, lista[27].Change);
            Assert.AreEqual((decimal)0.03980000, lista[28].Change);
            Assert.AreEqual((decimal)0.34910000, lista[29].Change);
            Assert.AreEqual((decimal)-1.14670000, lista[30].Change);
            Assert.AreEqual((decimal)-0.75770000, lista[31].Change);
            Assert.AreEqual((decimal)0.46860000, lista[32].Change);
        }

        [TestMethod]
        public void Test_That_Gain_Is_Correct()
        {
            Assert.AreEqual(0, lista[0].Gain);
            Assert.AreEqual(0, lista[1].Gain);
            Assert.AreEqual((decimal)0.05950000, lista[2].Gain);
            Assert.AreEqual(0, lista[3].Gain);
            Assert.AreEqual((decimal)0.71540000, lista[4].Gain);
            Assert.AreEqual((decimal)0.49860000, lista[5].Gain);
            Assert.AreEqual((decimal)0.26910000, lista[6].Gain);
            Assert.AreEqual((decimal)0.32900000, lista[7].Gain);
            Assert.AreEqual((decimal)0.41880000, lista[8].Gain);
            Assert.AreEqual((decimal)0.23930000, lista[9].Gain);
            Assert.AreEqual(0, lista[10].Gain);
            Assert.AreEqual((decimal)0.13970000, lista[11].Gain);
            Assert.AreEqual(0, lista[12].Gain);
            Assert.AreEqual((decimal)0.66800000, lista[13].Gain);
            Assert.AreEqual(0, lista[14].Gain);
            Assert.AreEqual(0, lista[15].Gain);
            Assert.AreEqual((decimal)0.03000000, lista[16].Gain);
            Assert.AreEqual((decimal)0.37880000, lista[17].Gain);
            Assert.AreEqual(0, lista[18].Gain);
            Assert.AreEqual(0, lista[19].Gain);
            Assert.AreEqual((decimal)0.56830000, lista[20].Gain);
            Assert.AreEqual((decimal)0.03990000, lista[21].Gain);
            Assert.AreEqual(0, lista[22].Gain);
            Assert.AreEqual((decimal)0.73780000, lista[23].Gain);
            Assert.AreEqual(0, lista[24].Gain);
            Assert.AreEqual(0, lista[25].Gain);
            Assert.AreEqual(0, lista[26].Gain);
            Assert.AreEqual((decimal)0.14950000, lista[27].Gain);
            Assert.AreEqual((decimal)0.03980000, lista[28].Gain);
            Assert.AreEqual((decimal)0.34910000, lista[29].Gain);
            Assert.AreEqual(0, lista[30].Gain);
            Assert.AreEqual(0, lista[31].Gain);
            Assert.AreEqual((decimal)0.46860000, lista[32].Gain);
        }

        [TestMethod]
        public void Test_That_Loss_Is_Correct()
        {
            Assert.AreEqual(0, lista[0].Loss);
            Assert.AreEqual((decimal)0.24870000, lista[1].Loss);
            Assert.AreEqual(0, lista[2].Loss);
            Assert.AreEqual((decimal)0.53730000, lista[3].Loss);
            Assert.AreEqual(0, lista[4].Loss);
            Assert.AreEqual(0, lista[5].Loss);
            Assert.AreEqual(0, lista[6].Loss);
            Assert.AreEqual(0, lista[7].Loss);
            Assert.AreEqual(0, lista[8].Loss);
            Assert.AreEqual(0, lista[9].Loss);
            Assert.AreEqual((decimal)0.18950000, lista[10].Loss);
            Assert.AreEqual(0, lista[11].Loss);
            Assert.AreEqual((decimal)0.41880000, lista[12].Loss);
            Assert.AreEqual(0, lista[13].Loss);
            Assert.AreEqual(0, lista[14].Loss);
            Assert.AreEqual((decimal)0.27920000, lista[15].Loss);
            Assert.AreEqual(0, lista[16].Loss);
            Assert.AreEqual(0, lista[17].Loss);
            Assert.AreEqual((decimal)0.18940000, lista[18].Loss);
            Assert.AreEqual((decimal)0.57830000, lista[19].Loss);
            Assert.AreEqual(0, lista[20].Loss);
            Assert.AreEqual(0, lista[21].Loss);
            Assert.AreEqual((decimal)0.53840000, lista[22].Loss);
            Assert.AreEqual(0, lista[23].Loss);
            Assert.AreEqual((decimal)0.66800000, lista[24].Loss);
            Assert.AreEqual((decimal)0.42870000, lista[25].Loss);
            Assert.AreEqual((decimal)1.32600000, lista[26].Loss);
            Assert.AreEqual(0, lista[27].Loss);
            Assert.AreEqual(0, lista[28].Loss);
            Assert.AreEqual(0, lista[29].Loss);
            Assert.AreEqual((decimal)1.14670000, lista[30].Loss);
            Assert.AreEqual((decimal)0.75770000, lista[31].Loss);
            Assert.AreEqual(0, lista[32].Loss);
        }

        [TestMethod]
        public void Test_That_AverageGain_Is_Correct()
        {
            Assert.AreEqual(0, lista[0].AverageGain);
            Assert.AreEqual(0, lista[1].AverageGain);
            Assert.AreEqual(0, lista[2].AverageGain);
            Assert.AreEqual(0, lista[3].AverageGain);
            Assert.AreEqual(0, lista[4].AverageGain);
            Assert.AreEqual(0, lista[5].AverageGain);
            Assert.AreEqual(0, lista[6].AverageGain);
            Assert.AreEqual(0, lista[7].AverageGain);
            Assert.AreEqual(0, lista[8].AverageGain);
            Assert.AreEqual(0, lista[9].AverageGain);
            Assert.AreEqual(0, lista[10].AverageGain);
            Assert.AreEqual(0, lista[11].AverageGain);
            Assert.AreEqual(0, lista[12].AverageGain);
            Assert.AreEqual(0, lista[13].AverageGain);
            Assert.AreEqual((decimal)0.23838571, Math.Round(lista[14].AverageGain, 8));
            Assert.AreEqual((decimal)0.22135816, Math.Round(lista[15].AverageGain, 8));
            Assert.AreEqual((decimal)0.20768972, Math.Round(lista[16].AverageGain, 8));
            Assert.AreEqual((decimal)0.21991189, Math.Round(lista[17].AverageGain, 8));
            Assert.AreEqual((decimal)0.20420389, Math.Round(lista[18].AverageGain, 8));
            Assert.AreEqual((decimal)0.18961790, Math.Round(lista[19].AverageGain, 8));
            Assert.AreEqual((decimal)0.21666662, Math.Round(lista[20].AverageGain, 8));
            Assert.AreEqual((decimal)0.20404044, Math.Round(lista[21].AverageGain, 8));
            Assert.AreEqual((decimal)0.18946612, Math.Round(lista[22].AverageGain, 8));
            Assert.AreEqual((decimal)0.22863282, Math.Round(lista[23].AverageGain, 8));
            Assert.AreEqual((decimal)0.21230191, Math.Round(lista[24].AverageGain, 8));
            Assert.AreEqual((decimal)0.19713749, Math.Round(lista[25].AverageGain, 8));
            Assert.AreEqual((decimal)0.18305624, Math.Round(lista[26].AverageGain, 8));
            Assert.AreEqual((decimal)0.18065936, Math.Round(lista[27].AverageGain, 8));
            Assert.AreEqual((decimal)0.17059798, Math.Round(lista[28].AverageGain, 8));
            Assert.AreEqual((decimal)0.18334812, Math.Round(lista[29].AverageGain, 8));
            Assert.AreEqual((decimal)0.17025183, Math.Round(lista[30].AverageGain, 8));
            Assert.AreEqual((decimal)0.15809098, Math.Round(lista[31].AverageGain, 8));
            Assert.AreEqual((decimal)0.18027020, Math.Round(lista[32].AverageGain, 8));
        }

        [TestMethod]
        public void Test_That_AverageLoss_Is_Correct()
        {
            Assert.AreEqual(0, lista[0].AverageLoss);
            Assert.AreEqual(0, lista[1].AverageLoss);
            Assert.AreEqual(0, lista[2].AverageLoss);
            Assert.AreEqual(0, lista[3].AverageLoss);
            Assert.AreEqual(0, lista[4].AverageLoss);
            Assert.AreEqual(0, lista[5].AverageLoss);
            Assert.AreEqual(0, lista[6].AverageLoss);
            Assert.AreEqual(0, lista[7].AverageLoss);
            Assert.AreEqual(0, lista[8].AverageLoss);
            Assert.AreEqual(0, lista[9].AverageLoss);
            Assert.AreEqual(0, lista[10].AverageLoss);
            Assert.AreEqual(0, lista[11].AverageLoss);
            Assert.AreEqual(0, lista[12].AverageLoss);
            Assert.AreEqual(0, lista[13].AverageLoss);
            Assert.AreEqual((decimal)0.09959286, Math.Round(lista[14].AverageLoss, 8));
            Assert.AreEqual((decimal)0.11242194, Math.Round(lista[15].AverageLoss, 8));
            Assert.AreEqual((decimal)0.10439180, Math.Round(lista[16].AverageLoss, 8));
            Assert.AreEqual((decimal)0.09693524, Math.Round(lista[17].AverageLoss, 8));
            Assert.AreEqual((decimal)0.10353987, Math.Round(lista[18].AverageLoss, 8));
            Assert.AreEqual((decimal)0.13745131, Math.Round(lista[19].AverageLoss, 8));
            Assert.AreEqual((decimal)0.12763336, Math.Round(lista[20].AverageLoss, 8));
            Assert.AreEqual((decimal)0.11851669, Math.Round(lista[21].AverageLoss, 8));
            Assert.AreEqual((decimal)0.14850835, Math.Round(lista[22].AverageLoss, 8));
            Assert.AreEqual((decimal)0.13790061, Math.Round(lista[23].AverageLoss, 8));
            Assert.AreEqual((decimal)0.17576486, Math.Round(lista[24].AverageLoss, 8));
            Assert.AreEqual((decimal)0.19383165, Math.Round(lista[25].AverageLoss, 8));
            Assert.AreEqual((decimal)0.27470082, Math.Round(lista[26].AverageLoss, 8));
            Assert.AreEqual((decimal)0.25507933, Math.Round(lista[27].AverageLoss, 8));
            Assert.AreEqual((decimal)0.23685938, Math.Round(lista[28].AverageLoss, 8));
            Assert.AreEqual((decimal)0.21994085, Math.Round(lista[29].AverageLoss, 8));
            Assert.AreEqual((decimal)0.28613793, Math.Round(lista[30].AverageLoss, 8));
            Assert.AreEqual((decimal)0.31982094, Math.Round(lista[31].AverageLoss, 8));
            Assert.AreEqual((decimal)0.29697659, Math.Round(lista[32].AverageLoss, 8));
        }

        [TestMethod]
        public void Test_That_RS_Is_Correct()
        {
            Assert.AreEqual(0, lista[0].RS);
            Assert.AreEqual(0, lista[1].RS);
            Assert.AreEqual(0, lista[2].RS);
            Assert.AreEqual(0, lista[3].RS);
            Assert.AreEqual(0, lista[4].RS);
            Assert.AreEqual(0, lista[5].RS);
            Assert.AreEqual(0, lista[6].RS);
            Assert.AreEqual(0, lista[7].RS);
            Assert.AreEqual(0, lista[8].RS);
            Assert.AreEqual(0, lista[9].RS);
            Assert.AreEqual(0, lista[10].RS);
            Assert.AreEqual(0, lista[11].RS);
            Assert.AreEqual(0, lista[12].RS);
            Assert.AreEqual(0, lista[13].RS);
            Assert.AreEqual(2.39, lista[14].RS);
            Assert.AreEqual(1.97, lista[15].RS);
            Assert.AreEqual(1.99, lista[16].RS);
            Assert.AreEqual(2.27, lista[17].RS);
            Assert.AreEqual(1.97, lista[18].RS);
            Assert.AreEqual(1.38, lista[19].RS);
            Assert.AreEqual(1.70, lista[20].RS);
            Assert.AreEqual(1.72, lista[21].RS);
            Assert.AreEqual(1.28, lista[22].RS);
            Assert.AreEqual(1.66, lista[23].RS);
            Assert.AreEqual(1.21, lista[24].RS);
            Assert.AreEqual(1.02, lista[25].RS);
            Assert.AreEqual(0.67, lista[26].RS);
            Assert.AreEqual(0.71, lista[27].RS);
            Assert.AreEqual(0.72, lista[28].RS);
            Assert.AreEqual(0.83, lista[29].RS);
            Assert.AreEqual(0.59, lista[30].RS);
            Assert.AreEqual(0.49, lista[31].RS);
            Assert.AreEqual(0.61, lista[32].RS);
        }

        [TestMethod]
        public void Test_That_RSI_Is_Correct()
        {
            Assert.AreEqual(0, lista[0].RSI);
            Assert.AreEqual(0, lista[1].RSI);
            Assert.AreEqual(0, lista[2].RSI);
            Assert.AreEqual(0, lista[3].RSI);
            Assert.AreEqual(0, lista[4].RSI);
            Assert.AreEqual(0, lista[5].RSI);
            Assert.AreEqual(0, lista[6].RSI);
            Assert.AreEqual(0, lista[7].RSI);
            Assert.AreEqual(0, lista[8].RSI);
            Assert.AreEqual(0, lista[9].RSI);
            Assert.AreEqual(0, lista[10].RSI);
            Assert.AreEqual(0, lista[11].RSI);
            Assert.AreEqual(0, lista[12].RSI);
            Assert.AreEqual(0, lista[13].RSI);
            Assert.AreEqual(70.53, lista[14].RSI);
            Assert.AreEqual(66.32, lista[15].RSI);
            Assert.AreEqual(66.55, lista[16].RSI);
            Assert.AreEqual(69.41, lista[17].RSI);
            Assert.AreEqual(66.36, lista[18].RSI);
            Assert.AreEqual(57.97, lista[19].RSI);
            Assert.AreEqual(62.93, lista[20].RSI);
            Assert.AreEqual(63.26, lista[21].RSI);
            Assert.AreEqual(56.06, lista[22].RSI);
            Assert.AreEqual(62.38, lista[23].RSI);
            Assert.AreEqual(54.71, lista[24].RSI);
            Assert.AreEqual(50.42, lista[25].RSI);
            Assert.AreEqual(39.99, lista[26].RSI);
            Assert.AreEqual(41.46, lista[27].RSI);
            Assert.AreEqual(41.87, lista[28].RSI);
            Assert.AreEqual(45.46, lista[29].RSI);
            Assert.AreEqual(37.30, lista[30].RSI);
            Assert.AreEqual(33.08, lista[31].RSI);
            Assert.AreEqual(37.77, lista[32].RSI);
        }

        [TestMethod]
        public void Test_That_Uptrend_Is_Correct()
        {
            Assert.AreEqual(false, lista[0].UpTrend);
            Assert.AreEqual(false, lista[1].UpTrend);
            Assert.AreEqual(false, lista[2].UpTrend);
            Assert.AreEqual(false, lista[3].UpTrend);
            Assert.AreEqual(false, lista[4].UpTrend);
            Assert.AreEqual(false, lista[5].UpTrend);
            Assert.AreEqual(false, lista[6].UpTrend);
            Assert.AreEqual(false, lista[7].UpTrend);
            Assert.AreEqual(false, lista[8].UpTrend);
            Assert.AreEqual(false, lista[9].UpTrend);
            Assert.AreEqual(false, lista[10].UpTrend);
            Assert.AreEqual(false, lista[11].UpTrend);
            Assert.AreEqual(false, lista[12].UpTrend);
            Assert.AreEqual(false, lista[13].UpTrend);
            Assert.AreEqual(false, lista[14].UpTrend);
            Assert.AreEqual(true, lista[15].UpTrend);
            Assert.AreEqual(true, lista[16].UpTrend);
            Assert.AreEqual(true, lista[17].UpTrend);
            Assert.AreEqual(true, lista[18].UpTrend);
            Assert.AreEqual(true, lista[19].UpTrend);
            Assert.AreEqual(true, lista[20].UpTrend);
            Assert.AreEqual(true, lista[21].UpTrend);
            Assert.AreEqual(true, lista[22].UpTrend);
            Assert.AreEqual(true, lista[23].UpTrend);
            Assert.AreEqual(true, lista[24].UpTrend);
            Assert.AreEqual(true, lista[25].UpTrend);
            Assert.AreEqual(true, lista[26].UpTrend);
            Assert.AreEqual(true, lista[27].UpTrend);
            Assert.AreEqual(true, lista[28].UpTrend);
            Assert.AreEqual(false, lista[29].UpTrend);
            Assert.AreEqual(false, lista[30].UpTrend);
            Assert.AreEqual(false, lista[31].UpTrend);
            Assert.AreEqual(false, lista[32].UpTrend);
        }

        [TestMethod]
        public void Test_That_StochasticRSI_Is_Correct()
        {
            Assert.AreEqual(0, lista[0].StochRSI);
            Assert.AreEqual(0, lista[1].StochRSI);
            Assert.AreEqual(0, lista[2].StochRSI);
            Assert.AreEqual(0, lista[3].StochRSI);
            Assert.AreEqual(0, lista[4].StochRSI);
            Assert.AreEqual(0, lista[5].StochRSI);
            Assert.AreEqual(0, lista[6].StochRSI);
            Assert.AreEqual(0, lista[7].StochRSI);
            Assert.AreEqual(0, lista[8].StochRSI);
            Assert.AreEqual(0, lista[9].StochRSI);
            Assert.AreEqual(0, lista[10].StochRSI);
            Assert.AreEqual(0, lista[11].StochRSI);
            Assert.AreEqual(0, lista[12].StochRSI);
            Assert.AreEqual(0, lista[13].StochRSI);
            Assert.AreEqual(0, lista[14].StochRSI);
            Assert.AreEqual(0, lista[15].StochRSI);
            Assert.AreEqual(0, lista[16].StochRSI);
            Assert.AreEqual(0, lista[17].StochRSI);
            Assert.AreEqual(0, lista[18].StochRSI);
            Assert.AreEqual(0, lista[19].StochRSI);
            Assert.AreEqual(0, lista[20].StochRSI);
            Assert.AreEqual(0, lista[21].StochRSI);
            Assert.AreEqual(0, lista[22].StochRSI);
            Assert.AreEqual(0, lista[23].StochRSI);
            Assert.AreEqual(0, lista[24].StochRSI);
            Assert.AreEqual(0, lista[25].StochRSI);
            Assert.AreEqual(0, lista[26].StochRSI);
            Assert.AreEqual(0.05, lista[27].StochRSI);
            Assert.AreEqual(0.06, lista[28].StochRSI);
            Assert.AreEqual(0.19, lista[29].StochRSI);
            Assert.AreEqual(0.00, lista[30].StochRSI);
            Assert.AreEqual(0.00, lista[31].StochRSI);
            Assert.AreEqual(0.16, lista[32].StochRSI);
        }
    }
}
