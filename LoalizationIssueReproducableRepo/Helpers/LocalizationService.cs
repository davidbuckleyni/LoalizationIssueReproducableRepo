using Microsoft.Extensions.Localization;
using SharedResourceLib.Lng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LoalizationIssueReproducableRepo.Helpers {
    public class LocalizationService {
        private readonly IStringLocalizer _localizer;

        public LocalizationService(IStringLocalizerFactory factory) {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString GetLocalizedHtmlString(string key) {
            return _localizer[key];
        }
    }
}
