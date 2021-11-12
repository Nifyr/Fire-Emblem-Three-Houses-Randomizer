// Decompiled with JetBrains decompiler
// Type: Fire_Emblem_Three_Houses_Randomizer_V2.FreeDay
// Assembly: Fire Emblem Three Houses Randomizer V2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 800CD4D2-D1E7-4E09-8822-0C2C01D464BA
// Assembly location: C:\Users\ninte\Desktop\Games\Switch\Fire Emblem Three Houses Randomizer.exe

using System.Collections.Generic;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    public class FreeDay
    {
        private int rareMonster;
        private int options;
        private int month;
        private int date;
        private int weekday;
        private int foodEvent;
        private int dayType;
        private int choirEvent;
        private int unk8;
        private int unk9;
        private int gardenEvent;
        private int fishEvent;
        private int tournamentChurch;
        private int tournamentLions;
        private int tournamentDeer;
        private int tournamentEagle;
        public int[] data;

        public FreeDay(List<int> sundayDates, int monthIndex, int[] tournaments, Settings settings)
        {
            this.rareMonster = (int)byte.MaxValue;
            if (Randomizer.p(settings.randRareMonsterSightingP))
                this.rareMonster = Randomizer.rng.Next(10, 13);
            this.month = monthIndex;
            this.date = sundayDates[Randomizer.rng.Next(0, sundayDates.Count)];
            sundayDates.Remove(this.date);
            if (settings.randRestrictFreedayP <= 75.0)
            {
                do
                {
                    int[] bits = new int[8];
                    for (int index = 0; index < 4; ++index)
                    {
                        if (Randomizer.p(settings.randRestrictFreedayP))
                            bits[index] = 1;
                    }
                    this.options = (int)Randomizer.toByte(bits);
                }
                while (this.options == 15 || (options == 13 && month == 4 && date == 27));
            }
            else
            {
                int[] bits = new int[8] { 1, 1, 1, 1, 0, 0, 0, 0 };
                bits[Randomizer.rng.Next(0, 4)] = 0;
                this.options = (int)Randomizer.toByte(bits);
            }
            this.weekday = 6;
            this.foodEvent = (int)byte.MaxValue;
            if (Randomizer.p(settings.randCafeteriaEventP))
                this.foodEvent = Randomizer.rng.Next(4, 15);
            this.dayType = 2;
            this.choirEvent = (int)byte.MaxValue;
            if (Randomizer.p(settings.randChoirEventP))
                this.choirEvent = 1;
            this.unk8 = 0;
            this.unk9 = 15;
            this.gardenEvent = (int)byte.MaxValue;
            if (Randomizer.p(settings.randGardenEventP))
                this.gardenEvent = 0;
            this.fishEvent = (int)byte.MaxValue;
            if (Randomizer.p(settings.randFishingEventP))
                this.fishEvent = Randomizer.rng.Next(1, 6);
            this.tournamentChurch = tournaments[0];
            this.tournamentLions = tournaments[1];
            this.tournamentDeer = tournaments[2];
            this.tournamentEagle = tournaments[3];
            this.data = new int[16]
            {
        this.rareMonster,
        this.options,
        this.month,
        this.date,
        this.weekday,
        this.foodEvent,
        this.dayType,
        this.choirEvent,
        this.unk8,
        this.unk9,
        this.gardenEvent,
        this.fishEvent,
        this.tournamentChurch,
        this.tournamentLions,
        this.tournamentDeer,
        this.tournamentEagle
            };
        }
    }
}
