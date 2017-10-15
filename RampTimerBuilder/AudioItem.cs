namespace RampTimerBuilder
{
    class AudioItem
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            AudioItem obj1 = obj as AudioItem;
            if (obj1 == null) return false;
            return obj1.Value == Value;
        }
    }
}
