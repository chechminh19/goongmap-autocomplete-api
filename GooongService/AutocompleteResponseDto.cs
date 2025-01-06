using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoongService
{
    public class AutocompleteResponseDto
    {
        public List<PredictionDto> Predictions { get; set; }
        public string ExecutionTime { get; set; }
        public string Status { get; set; }
    }
    public class PredictionDto
    {
        public string Description { get; set; }
        public List<MatchedSubstringDto> MatchedSubstrings { get; set; }
        public string PlaceId { get; set; }
        public string Reference { get; set; }
        public StructuredFormattingDto StructuredFormatting { get; set; }
        public bool HasChildren { get; set; }
        public PlusCodeDto PlusCode { get; set; }
        public CompoundDto Compound { get; set; }
        public List<TermDto> Terms { get; set; }
        public List<string> Types { get; set; }
        public int? DistanceMeters { get; set; }
    }
    public class MatchedSubstringDto
    {
        public int Length { get; set; }
        public int Offset { get; set; }
    }

    public class StructuredFormattingDto
    {
        public string MainText { get; set; }
        public List<MatchedSubstringDto> MainTextMatchedSubstrings { get; set; }
        public string SecondaryText { get; set; }
        public List<MatchedSubstringDto> SecondaryTextMatchedSubstrings { get; set; }
    }

    public class PlusCodeDto
    {
        public string CompoundCode { get; set; }
        public string GlobalCode { get; set; }
    }

    public class CompoundDto
    {
        public string District { get; set; }
        public string Commune { get; set; }
        public string Province { get; set; }
    }

    public class TermDto
    {
        public int Offset { get; set; }
        public string Value { get; set; }
    }
}
