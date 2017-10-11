using System.Text;

namespace RampTimerBuilder
{
    static class BaseIntervalBuilder
    {
        public static string  BuildBaseIntervalString(int BaseInterval)
        {
            var intervalString = new StringBuilder();
            intervalString.Append(BaseInterval + "-Minute Base~16,");
            intervalString.Append((BaseInterval * 2).ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + ",");
            intervalString.Append((BaseInterval * 2).ToString() + ",");
            intervalString.Append((BaseInterval * 3).ToString() + ",");
            intervalString.Append((BaseInterval * 4).ToString() + ",");
            intervalString.Append((BaseInterval * 5).ToString() + ",");
            intervalString.Append((BaseInterval * 5).ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + ",");
            intervalString.Append(BaseInterval.ToString() + "~0~Beep Short.wav~~1");
            return intervalString.ToString();
        }
    }
}
