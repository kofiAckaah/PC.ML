namespace PC.ML.Core.RequestDtos
{
    public class PriceCheckerRequestDto
    {
        public string CPU { get; set; } = string.Empty;
        public float GHz { get; set; } = 0f;
        public string GPU { get; set; } = string.Empty;
        public float RAM { get; set; } = 0f;
        public string RAMType { get; set; } = string.Empty;
        public float Screen { get; set; } = 0f;
        public float Storage { get; set; } = 0f;
        public bool SSD { get; set; }
        public float Weight { get; set; } = 0f;
    }
}
