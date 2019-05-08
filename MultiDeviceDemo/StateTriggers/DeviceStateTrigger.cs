using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace MultiDeviceDemo.StateTriggers
{
    public class DeviceStateTrigger : StateTriggerBase
    {
        private string _deviceFamily;

        public string DeviceFamily
        {
            get { return _deviceFamily; }
            set
            {
                _deviceFamily = value;
                SetActive(_deviceFamily == Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily);

            }
        }
    }
}
