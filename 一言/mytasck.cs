using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;

namespace 一言
{
    public class mytasck
    {
        ApplicationDataContainer com = ApplicationData.Current.LocalSettings.CreateContainer("setting", ApplicationDataCreateDisposition.Always);
        public async static void tasck(int s)
        {
            //注册后台任务
            var taskt = BackgroundTaskRegistration.AllTasks.Values;
            var task = BackgroundTaskRegistration.AllTasks.Values.FirstOrDefault(t => t.Name == "task"+s.ToString());
            foreach(var i in taskt)
            {
                if(i.Name!="task"+s.ToString())
                {
                    i.Unregister(true);
                }
            }
                if (task == null)
                {
                    var res = await BackgroundExecutionManager.RequestAccessAsync();
                    if (res != BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity)
                        return;

                    // 注册
                    BackgroundTaskBuilder bd = new BackgroundTaskBuilder();
                    bd.Name = "task" + s.ToString(); //任务名
                    bd.TaskEntryPoint = "Basktask.task1"; //入口点
                    // 设置触发器为计时器
                    //bd.SetTrigger(new TimeTrigger(30, false));
                    switch (s)
                    {
                        case 30:
                            bd.SetTrigger(new TimeTrigger(30, false));
                            break;
                        case 60:
                            bd.SetTrigger(new TimeTrigger(60, false));
                            break;
                        case 180:
                            bd.SetTrigger(new TimeTrigger(180, false));
                            break;
                        case 360:
                            bd.SetTrigger(new TimeTrigger(360, false));
                            break;
                        case 720:
                            bd.SetTrigger(new TimeTrigger(720, false));
                            break;
                    }
                    BackgroundTaskRegistration reg = bd.Register();
                }
        }
    }
}
