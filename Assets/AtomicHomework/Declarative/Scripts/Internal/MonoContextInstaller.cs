using System;
using System.Collections.Generic;

namespace Declarative
{
    internal static class MonoContextInstaller
    {
        internal static void RegisterElements(object section, MonoContext monoContext, List<IDisposable> disposables)
        {
            var sectionType = section.GetType();
            var fields = ReflectionUtils.RetrieveFields(sectionType);

            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var field = fields[i];
                var fieldValue = field.GetValue(section);
                
                if (fieldValue is IMonoElement listener)
                {
                    monoContext.AddListener(listener);
                }

                if (fieldValue is IDisposable disposable)
                {
                    disposables.Add(disposable);
                }
            }
        }
    }
}