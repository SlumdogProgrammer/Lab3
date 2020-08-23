using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs
{
  delegate TKey KeySelector<TKey>(ResearchTeam rt);
  class ResearchTeamCollection<TKey>
  {
    private Dictionary<TKey, ResearchTeam> _TKeyResearchTeams;
    private KeySelector<TKey> _KeySelector;

    public ResearchTeamCollection(KeySelector<TKey> keySelector)
    {
      _KeySelector = keySelector;
      _TKeyResearchTeams = new Dictionary<TKey, ResearchTeam>();
    }

    public DateTime LastPaper
    {
      get => _TKeyResearchTeams.Count == 0 ?
        new DateTime() : _TKeyResearchTeams.Values.Max(rt => rt.Papers.Max(p => p.Date));
    }

    public IEnumerable<IGrouping<TimeFrame, KeyValuePair<TKey, ResearchTeam>>> GroupByTimeFrame
    {
      get => _TKeyResearchTeams.GroupBy(pair => pair.Value.TimeFrame);
    }

    public IEnumerable<KeyValuePair<TKey, ResearchTeam>> TimeFrameGroup(TimeFrame value) =>
      _TKeyResearchTeams.Where(tf => tf.Value.TimeFrame == value);
    

    public void AddDefaults16()
    {
      ResearchTeam rt = new ResearchTeam();
      for (int i = 0; i < 16; i++)
        _TKeyResearchTeams.Add(_KeySelector(rt), rt);
    }

    public void AddResearchTeams(params ResearchTeam[] researchTeams)
    {
      foreach (var rt in researchTeams)
        _TKeyResearchTeams.Add(_KeySelector(rt), rt);
    }

    public string ToShortString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (var trt in _TKeyResearchTeams)
        stringBuilder.AppendLine($"Ключ: {trt.Key} значение:\n{trt.Value.ToShortString()}");
      return stringBuilder.ToString();
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (var trt in _TKeyResearchTeams)
        stringBuilder.AppendLine($"Ключ: {trt.Key} значение:\n{trt.Value}");
      return stringBuilder.ToString();
    }

  }
}
