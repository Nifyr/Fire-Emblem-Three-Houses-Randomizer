using System.Collections.Generic;

namespace Fire_Emblem_Three_Houses_Randomizer_V2
{
    public class Month
    {
        public int monthIndex;
        public int missionDate;
        public int missionWeekday;
        public int startDate;
        public int startWeekday;
        public int firstSunday;
        public int[] tournaments;
        private List<FreeDay> freeDays;
        public List<int> sundayDates;
        private Settings settings;

        public Month(Settings importedSettings)
        {
            this.monthIndex = 0;
            this.startDate = 1;
            this.missionDate = 1;
            this.startWeekday = 0;
            this.missionWeekday = 0;
            this.firstSunday = 0;
            this.tournaments = new int[4]
            {
        (int) byte.MaxValue,
        (int) byte.MaxValue,
        (int) byte.MaxValue,
        (int) byte.MaxValue
            };
            this.freeDays = new List<FreeDay>();
            this.settings = importedSettings;
        }

        public void setSundays()
        {
            this.firstSunday %= 7;
            while (this.firstSunday <= this.startDate)
                this.firstSunday += 7;
            this.sundayDates = new List<int>();
            for (int firstSunday = this.firstSunday; firstSunday < this.missionDate; firstSunday += 7)
                this.sundayDates.Add(firstSunday);
        }

        public List<int[]> generateData(int freedayCount)
        {
            List<int[]> numArrayList = new List<int[]>();
            numArrayList.Add(this.getStartData());
            for (int index = 0; index < freedayCount; ++index)
            {
                this.freeDays.Add(new FreeDay(this.sundayDates, this.monthIndex, this.tournaments, this.settings));
                numArrayList.Add(this.freeDays[index].data);
            }
            numArrayList.Add(this.getMissionData());
            return numArrayList;
        }

        private int[] getStartData() => new int[16]
        {
      (int) byte.MaxValue,
      0,
      this.monthIndex,
      this.startDate,
      this.startWeekday,
      (int) byte.MaxValue,
      1,
      (int) byte.MaxValue,
      (int) byte.MaxValue,
      0,
      (int) byte.MaxValue,
      (int) byte.MaxValue,
      (int) byte.MaxValue,
      (int) byte.MaxValue,
      (int) byte.MaxValue,
      (int) byte.MaxValue
        };

        private int[] getMissionData() => new int[16]
        {
      (int) byte.MaxValue,
      0,
      this.monthIndex,
      this.missionDate,
      this.missionWeekday,
      (int) byte.MaxValue,
      3,
      (int) byte.MaxValue,
      (int) byte.MaxValue,
      0,
      (int) byte.MaxValue,
      (int) byte.MaxValue,
      (int) byte.MaxValue,
      (int) byte.MaxValue,
      (int) byte.MaxValue,
      (int) byte.MaxValue
        };
    }
}
