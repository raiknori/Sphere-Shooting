using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] InputController inputController;
    [SerializeField] PhoneInputController phoneInputController;
    [SerializeField] GameFlow gameflow;
    [SerializeField] SizeController sizeController;
    [SerializeField] DeffaultCheckObstacle deffaultCheckObstacle;

    public override void InstallBindings()
    {
        CheckDevice();
        Container.Bind<IGameOver>().To<GameFlow>().FromInstance(gameflow).AsSingle();
        Container.Bind<ISize>().To<SizeController>().FromInstance(sizeController).AsSingle();
        Container.Bind<ICheckObstacle>().To<DeffaultCheckObstacle>().FromInstance(deffaultCheckObstacle).AsSingle();
    }

    void CheckDevice()
    {
        if (Application.isMobilePlatform)
        {
            Container.Bind<IHoldInput>().To<PhoneInputController>().FromInstance(phoneInputController).AsSingle();

            phoneInputController.gameObject.SetActive(true);
            inputController.gameObject.SetActive(false);
        }
        else
        {
            Container.Bind<IHoldInput>().To<InputController>().FromInstance(inputController).AsSingle();

            phoneInputController.gameObject.SetActive(false);
            inputController.gameObject.SetActive(true);
        }
    }    
}
