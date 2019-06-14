using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacTec.TA.Library;
namespace TM.Objects
{
   public  class TMCandlePattern
    {
       List<string> _bullishPatternFormed = new List<string>();
       List<string> _bearishPatternFormed = new List<string>();

       public bool BullishPatternFormed
       {
           get
           {
               return _bullishPatternFormed.Count>0;
           }
       }
       public bool BearishPatternFormed
       {
           get
           {
               return _bearishPatternFormed.Count>0;
           }
       }
       private void SetCandleResult(int[] result, string candle)
       {
           if (result[0]>0) //bullish
           {
               _bullishPatternFormed.Add(candle);
           }
           else if (result[0] < 0)//bearish
           {
               _bullishPatternFormed.Add(candle);
           }
           //else do nothing

       }
       public TMCandlePattern(TMPriceBar PriceBar)
       {
           
           #region "====Details on patterns ====

           /*
            * BULLISH REVERSAL PATTERNS
                   HIGH RELIABILITY
                ----------------------------
                1. Piercing Line
                2. Kicking 
                3. Abandoned Baby 
                4. Morning Doji Star
                5. Morning Star 
                6. Three Inside Up 
                7. Three Outside Up 
                8. Three White Soldiers  
                9. Concealing Baby Swallow 

                MEDIUM RELIABILITY
                ------------------
                10. Dragonfly Doji
                11. Long Legged Doji 
                12. Engulfing 
                13. Gravestone Doji
                14. Doji Star 
                15. Harami Cross
                16. Homing Pigeon 
                17. Matching Low
                18. Meeting Lines 
                19. Stick Sandwich 
                20. Three Stars in the South 
                21. Tri Star 
                22. Three River 
                23. Breakaway 
                24. Ladder Bottom 

                LOW RELIABILITY
                -------------
                Belt Hold 
                Hammer 
                Inverted Hammer 
                Harami 


                BULLISH CONTINUATION PATTERNS
                 HIGH RELIABILITY
                --------------
                25. Side-by-side White Lines
                26. Mat Hold 
                27. Rising Three Methods 

                MEDIUM RELIABILITY
                -------------------
                28. Upside Gap Three Methods 
                29. Upside Tasuki Gap 

                LOW RELIABILITY
                ----------------
                Separating Lines 
                Three Line Strike 



                BEARISH REVERSAL PATTERNS
                HIGH RELIABILITY
                ------------------
                1. Dark Cloud Cover 
                2. Kicking
                3. Abandoned Baby 
                4. Evening Star 
                5. Evening Doji Star 
                6. Three Black Crows
                7. Three Inside Down
                8. Three Outside Down 
                9. Upside Gap Two Crows 


                MEDIUM RELIABILITY
                ----------------
                10. Dragonfly Doji 
                11. Long Legged Doji 
                12. Engulfing 
                13. Gravestone Doji 
                14. Doji Star 
                15. Harami Cross 
                16 Meeting Lines
                17. Advance Block 
                18. Deliberation 
                19. Tri Star 
                20. Two Crows 
                21. Breakaway 

                LOW RELIABILITY
                ----------------
                Belt Hold 
                Hanging Man 
                Shooting Star 
                Harami 


                BEARISH CONTINUATION PATTERNS
                ------------------------
                22. Falling Three Methods

                MEDIUM RELIABILITY
                ------------------
                23. In Neck 
                24. On Neck
                25. Downside Gap Three Methods
                26. Downside Tasuki Gap 
                27. Side By Side White Lines 


                LOW RELIABILITY
                -------------
                Separating Lines 
                Thrusting 
                Three Line Strike 



            * */
           #endregion

           VerifyPatterns(PriceBar);
       }
       
       private void VerifyPatterns(TMPriceBar PriceBar)
       {
           TicTacTec.TA.Library.Core.RetCode retCode;
           int outBegIndex;
           int outNBElement;
           int[] output = new int[1];

           //-------------------------------------ALL BULLISH PATTERNS CHECK HERE -----------------------------------------------------
           retCode = Core.CdlPiercing(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output,"Piercing");

           retCode = Core.CdlKicking(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);//IF -VE THEN BEARISH
           SetCandleResult(output, "Kicking");

           retCode = Core.CdlAbandonedBaby(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close,0.3, out outBegIndex, out outNBElement, output);//IF -VE THEN BEARISH
           SetCandleResult(output, "AbandonedBaby");

           retCode = Core.CdlMorningDojiStar(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close,0.3, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "MorningDojiStar");

           retCode = Core.CdlMorningStar(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, 0.3,out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "MorningStar");

           retCode = Core.Cdl3Inside(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);//IF -VE THEN BEARISH
           SetCandleResult(output, "3Inside");

           retCode = Core.Cdl3Outside(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);//IF -VE THEN BEARISH
           SetCandleResult(output, "3Outside");

           retCode = Core.Cdl3WhiteSoldiers(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "3WhiteSoldiers");

           retCode = Core.CdlConcealBabysWall(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "ConcealBabysWall");

           retCode = Core.CdlDragonflyDoji(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);//IF -VE THEN BEARISH
           SetCandleResult(output, "DragonflyDoji");

           retCode = Core.CdlLongLeggedDoji(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);//IF -VE THEN BEARISH
           SetCandleResult(output, "LongLeggedDoji");

           retCode = Core.CdlEngulfing(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);//IF -VE THEN BEARISH
           SetCandleResult(output, "Engulfing");

           retCode = Core.CdlGravestoneDoji(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);//IF -VE THEN BEARISH
           SetCandleResult(output, "GravestoneDoji");

           retCode = Core.CdlDojiStar(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output); //IF -VE THEN BEARISH
           SetCandleResult(output, "DojiStar");

           retCode = Core.CdlHaramiCross(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output); //IF -VE THEN BEARISH
           SetCandleResult(output, "HaramiCross");

           retCode = Core.CdlHomingPigeon(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "HomingPigeon");

           retCode = Core.CdlMatchingLow(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "MatchingLow");

           //Meeting Lines -missing here //IF -VE THEN BEARISH

           retCode = Core.CdlStickSandwhich(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "StickSandwhich");

           retCode = Core.Cdl3StarsInSouth(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "3StarsInSouth");

           retCode = Core.CdlTristar(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);//IF -VE THEN BEARISH
           SetCandleResult(output, "Tristar");

           retCode = Core.CdlUnique3River(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "Unique3River");

           retCode = Core.CdlBreakaway(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);//IF -VE THEN BEARISH
           SetCandleResult(output, "Breakaway");

           retCode = Core.CdlLadderBottom(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "LadderBottom");

           //BEARISH
           retCode = Core.CdlDarkCloudCover(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close,0.5, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "DarkCloudCover");

           retCode = Core.CdlEveningStar(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close,0.3, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "EveningStar");

           retCode = Core.CdlEveningDojiStar(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close,0.3, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "EveningDojiStar");

           retCode = Core.Cdl3BlackCrows(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "3BlackCrows");

           retCode = Core.CdlUpsideGap2Crows(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "UpsideGap2Crows");

           retCode = Core.CdlAdvanceBlock(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "AdvanceBlock");

           //Deliberation -missing

           retCode = Core.Cdl2Crows(0, 2, PriceBar.Open, PriceBar.High, PriceBar.Low, PriceBar.Close, out outBegIndex, out outNBElement, output);
           SetCandleResult(output, "2Crows");
       }

    }
}
