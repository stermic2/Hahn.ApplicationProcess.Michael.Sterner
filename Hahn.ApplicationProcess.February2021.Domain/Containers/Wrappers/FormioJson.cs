using DynamicCQ.Interfaces;

namespace Hahn.ApplicationProcess.February2021.Domain.Containers.Wrappers
{
    public class FormioJson<TDto>
    where TDto : IDto
    {
        public TDto data { get; set; }
        public Empty metadata { get; set; }
    }
}