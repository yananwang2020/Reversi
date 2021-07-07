using Reversi.Monos;
using UnityEngine;
using Zenject;
using Reversi.Models;

namespace Reversi.Controller
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ModelBoard>().AsSingle();
        }
    }
}