using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ApiDemo
{
    class IsPropertyPresentTrigger : StateTriggerBase
    {
        public string TypeName { get; set; }
        public string PropertyName { get; set; }

        private Boolean _isPresent;
        private bool? _isPropertyPresent = null;

        public Boolean IsPresent
        {
            get { return _isPresent; }
            set
            {
                _isPresent = value;
                if (_isPropertyPresent == null)
                {
                    // Call into ApiInformation method to determine if property is present.
                    //_isPropertyPresent =
                    //ApiInformation.IsPropertyPresent(TypeName, PropertyName);
                }

                // If the property presence matches _isPresent then the trigger will be activated;
                SetActive(_isPresent == _isPropertyPresent);
            }
        }
    }
}
