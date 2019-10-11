using System;
using System.Linq;
using System.Collections.Generic;
using DeepWinter.RRuleParserNet.Tokenizer.Token;

namespace DeepWinter.RRuleParserNet.Tokenizer
{
  public class RRuleTokenContainer : IRRuleTokenContainer
  {
    private Dictionary<Type, IRRuleToken> _tokenInstancesMap;

    public static RRuleTokenContainer EmptyTokenContainer()
    {
      return new RRuleTokenContainer(new IRRuleToken[0]);
    }

    public RRuleTokenContainer(ICollection<IRRuleToken> tokens)
    {
      _tokenInstancesMap = new Dictionary<Type, IRRuleToken>();
      foreach (var token in tokens)
      {
        AddOrUpdateToken(token);
      }
    }

    public ByDayToken GetByDay()
    {
      return (ByDayToken)GetTokenOrNull(typeof(ByDayToken));
    }

    public ByMonthDayToken GetByMontDay()
    {
      return (ByMonthDayToken)GetTokenOrNull(typeof(ByMonthDayToken));
    }

    public ByMonthToken GetByMonth()
    {
      return (ByMonthToken)GetTokenOrNull(typeof(ByMonthToken));
    }

    public BySetPosToken GetBySetPos()
    {
      return (BySetPosToken)GetTokenOrNull(typeof(BySetPosToken));
    }

    public CountToken GetCount()
    {
      return (CountToken)GetTokenOrNull(typeof(CountToken));
    }

    public FreqToken GetFreq()
    {
      return (FreqToken)GetTokenOrNull(typeof(FreqToken));
    }

    public IntervalToken GetInterval()
    {
      return (IntervalToken)GetTokenOrNull(typeof(IntervalToken));
    }

    public UntilToken GetUntil()
    {
      return (UntilToken)GetTokenOrNull(typeof(UntilToken));
    }

    public void Merge(IRRuleTokenContainer tokenContainer)
    {
      if (tokenContainer.GetFreq() != null && GetFreq() == null)
        AddOrUpdateToken(tokenContainer.GetFreq());

      if (tokenContainer.GetUntil() != null && GetUntil() == null)
        AddOrUpdateToken(tokenContainer.GetUntil());

      if (tokenContainer.GetCount() != null && GetCount() == null)
        AddOrUpdateToken(tokenContainer.GetCount());

      if (tokenContainer.GetInterval() != null && GetInterval() == null)
        AddOrUpdateToken(tokenContainer.GetInterval());

      if (tokenContainer.GetByDay() != null && GetByDay() == null)
        AddOrUpdateToken(tokenContainer.GetByDay());

      if (tokenContainer.GetByMontDay() != null && GetByMontDay() == null)
        AddOrUpdateToken(tokenContainer.GetByMontDay());

      if (tokenContainer.GetByMonth() != null && GetByMonth() == null)
        AddOrUpdateToken(tokenContainer.GetByMonth());

      if (tokenContainer.GetBySetPos() != null && GetBySetPos() == null)
        AddOrUpdateToken(tokenContainer.GetBySetPos());
    }

    public int RuleCount()
    {
      return _tokenInstancesMap.Keys.Count;
    }

    /// <summary>
    /// Checks if the given container is equals to the current container.
    /// Will check if the <see cref="this#tokenInstancesMap"></see> has different sizes.
    /// And als if the value each token is equal.
    /// </summary>
    /// <param name="obj">Container to check against</param>
    /// <returns><code>true</code> if the containers are equal, <code>false</code> otherwise.</returns>
    public override bool Equals(object obj)
    {
      // Can currently only compare with it self.
      if (obj is RRuleTokenContainer)
      {
        var foreignTokenContainer = (RRuleTokenContainer)obj;

        // Different sized containers can't be equal.
        if (foreignTokenContainer._tokenInstancesMap.Count != _tokenInstancesMap.Count)
          return false;

        foreach (var cToken in foreignTokenContainer._tokenInstancesMap.Values)
          if (!cToken.GetValue().Equals(GetTokenOrNull(cToken.GetType())?.GetValue()))
            return false;

        return true;
      }

      return false;
    }

    public override int GetHashCode()
    {
      return ToString().GetHashCode();
    }

    /// <summary>
    /// Converts the tokens in the container to joined string.
    /// </summary>
    /// <returns> Current tokens as valid RRule.</returns>
    public override string ToString()
    {
      return string.Join(",", _tokenInstancesMap.Values.Select(v => {
        return $"{v.GetName()}={v.GetValue().ToString()}";
      }));  
    }

    private IRRuleToken GetTokenOrNull(Type type)
    {
      if (!_tokenInstancesMap.ContainsKey(type))
      {
        return null;
      }

      return _tokenInstancesMap[type];
    }

    private void AddOrUpdateToken(IRRuleToken token)
    {
      if (_tokenInstancesMap.ContainsKey(token.GetType()))
      {
        _tokenInstancesMap[token.GetType()] = token;
      }
      else
      {
        _tokenInstancesMap.Add(token.GetType(), token);
      }
    }
  }
}
