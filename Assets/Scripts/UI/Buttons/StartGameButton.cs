using Signals.Buttons;

namespace UI.Buttons
{
    public class StartGameButton : BaseButton<StartGameSignal> // тут просто нужно сделать наследование от BaseButton<Сюда создать структуру
                                 // (папка Signal/Buttons/нужная структура) сигнала и положить в контейнер(это просходит в SignalsInstaller(и он же устанавливается
                                 // в GameMonoInstaller))> 
    {
        // этот пустой скрипт нужно будет повесить на кнопку, потом в UIController попросить SignalBus и подписаться на событие (StartGameSignal)
        // + на UIController нужно установить компонент ZenjectBin
    }
}