using System.Collections.Generic;

namespace App.Application.Common.Configs
{
    public class DevConfig
    {
        public bool EnableSupportsInProduction { get; set; }


        public List<MockServiceConfig> MockServices { get; set; }

        public List<DevSupportConfig> DevSupports { get; set; }
    }

    /**
     * Enable fixtures
     */
    public class DevSupportConfig
    {
        public string Name { get; set; }

        public bool Enable { get; set; }

        public int ExecutionOrder { get; set; }

        public Dictionary<string, object> Options { get; set; }
    }

    public class MockServiceConfig
    {
        public bool Enable { get; set; }

        public string InterfaceTypeName { get; set; }
    }
}
