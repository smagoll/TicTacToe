using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IMiniGame
{
    UniTask<MiniGameOutcome> Play();
}