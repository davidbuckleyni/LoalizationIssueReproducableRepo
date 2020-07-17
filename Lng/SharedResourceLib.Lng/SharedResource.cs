using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedResourceLib.Lng {
    public interface ISharedResource {
    }
    public class SharedResource : ISharedResource {
        private readonly IStringLocalizer _localizer;

        public SharedResource(IStringLocalizer<SharedResource> localizer) {

            _localizer = localizer;
        }

        public string GetResourceValueByKey(string resourceKey) {
            return _localizer[resourceKey];
        }
    }
}
 
