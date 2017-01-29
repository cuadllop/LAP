﻿// -----------------------------------------------------------------------------------------
//  <auto-generated>
//      This code is auto-generated and changes to this file will be lost when regenerated.
//  </auto-generated>
// -----------------------------------------------------------------------------------------
// ReSharper disable once CheckNamespace
namespace Endjin.SpecFlow.Selenium.Framework
{
    #region Using Directives

    using Endjin.SpecFlow.Selenium.Framework.Environment;
    using Endjin.SpecFlow.Selenium.Framework.Navigation;

    using TechTalk.SpecFlow;

    #endregion

    [Binding]
    public class FeatureHooks
    {
        [BeforeFeature]
        public static void FeatureSetup()
        {
			if (TestEnvironment.Current.IsLocal && TestEnvironment.Current.AutoStartLocalIIS)
			{
				TestEnvironment.Current.StartWebsite();
			}
        }

        [AfterFeature]
        public static void FeatureTeardown()
        {
            TestEnvironment.Current.StopWebsite();
        }
    }

    [Binding]
    public class WebTestSetupHooks
    {
        [BeforeScenario]
        public static void BeforeScenarioSetup()
        {            
            BrowserTest.Setup(new WebsiteNavigationMap());
        }
    }

    [Binding]
    public class WebTestTeardownHooks
    {
        [AfterScenario]
        public static void ScenarioTeardown()
        {
            BrowserTest.Teardown();
        }
    }
}

namespace  Specs.Features.ContentManagement
{
    #region Using Directives
    
    using System.Diagnostics;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using Endjin.SpecFlow.Selenium.Framework;
    using Endjin.SpecFlow.Selenium.Framework.Features;

    #endregion

        public partial class  NotificationsManagementFeature : BrowserTestFeature
        {
            public  NotificationsManagementFeature()
            {
            }

            public  NotificationsManagementFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  PromotionsFeature : BrowserTestFeature
        {
            public  PromotionsFeature()
            {
            }

            public  PromotionsFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
}
namespace  Specs.Features.CustomersManagement
{
    #region Using Directives
    
    using System.Diagnostics;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using Endjin.SpecFlow.Selenium.Framework;
    using Endjin.SpecFlow.Selenium.Framework.Features;

    #endregion

        public partial class  HomeFeature : BrowserTestFeature
        {
            public  HomeFeature()
            {
            }

            public  HomeFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  AdminOrgsFeature : BrowserTestFeature
        {
            public  AdminOrgsFeature()
            {
            }

            public  AdminOrgsFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
}
namespace  Specs.Features.ControlPanel
{
    #region Using Directives
    
    using System.Diagnostics;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using Endjin.SpecFlow.Selenium.Framework;
    using Endjin.SpecFlow.Selenium.Framework.Features;

    #endregion

        public partial class  CPHomeFeature : BrowserTestFeature
        {
            public  CPHomeFeature()
            {
            }

            public  CPHomeFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
}
namespace  Specs.Features.CustomersManagement.Organisations.Creation
{
    #region Using Directives
    
    using System.Diagnostics;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using Endjin.SpecFlow.Selenium.Framework;
    using Endjin.SpecFlow.Selenium.Framework.Features;

    #endregion

        public partial class  BulkOrganisationsCreate_BackendFeature : BrowserTestFeature
        {
            public  BulkOrganisationsCreate_BackendFeature()
            {
            }

            public  BulkOrganisationsCreate_BackendFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  BulkOrganisationsCreate_SalesPortalFeature : BrowserTestFeature
        {
            public  BulkOrganisationsCreate_SalesPortalFeature()
            {
            }

            public  BulkOrganisationsCreate_SalesPortalFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  OrganisationsCreate_AutoRegisterFeature : BrowserTestFeature
        {
            public  OrganisationsCreate_AutoRegisterFeature()
            {
            }

            public  OrganisationsCreate_AutoRegisterFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  OrganisationsCreate_BackendFeature : BrowserTestFeature
        {
            public  OrganisationsCreate_BackendFeature()
            {
            }

            public  OrganisationsCreate_BackendFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  OrganisationsCreate_SalesPortalFeature : BrowserTestFeature
        {
            public  OrganisationsCreate_SalesPortalFeature()
            {
            }

            public  OrganisationsCreate_SalesPortalFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
}
namespace  Specs.Features.CustomersManagement.Organisations.Delete
{
    #region Using Directives
    
    using System.Diagnostics;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using Endjin.SpecFlow.Selenium.Framework;
    using Endjin.SpecFlow.Selenium.Framework.Features;

    #endregion

        public partial class  BulkOrganisationsDelete_BackendFeature : BrowserTestFeature
        {
            public  BulkOrganisationsDelete_BackendFeature()
            {
            }

            public  BulkOrganisationsDelete_BackendFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  BulkOrganisationsDelete_SalesPortalFeature : BrowserTestFeature
        {
            public  BulkOrganisationsDelete_SalesPortalFeature()
            {
            }

            public  BulkOrganisationsDelete_SalesPortalFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  OrganisationsDelete_BackendFeature : BrowserTestFeature
        {
            public  OrganisationsDelete_BackendFeature()
            {
            }

            public  OrganisationsDelete_BackendFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  OrganisationsDelete_SalesPortalFeature : BrowserTestFeature
        {
            public  OrganisationsDelete_SalesPortalFeature()
            {
            }

            public  OrganisationsDelete_SalesPortalFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
}
namespace  Specs.Features.CustomersManagement.Organisations.Edition
{
    #region Using Directives
    
    using System.Diagnostics;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using Endjin.SpecFlow.Selenium.Framework;
    using Endjin.SpecFlow.Selenium.Framework.Features;

    #endregion

        public partial class  OrganisationsEdit_BackendFeature : BrowserTestFeature
        {
            public  OrganisationsEdit_BackendFeature()
            {
            }

            public  OrganisationsEdit_BackendFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  OrganisationsEdit_ControlPanelFeature : BrowserTestFeature
        {
            public  OrganisationsEdit_ControlPanelFeature()
            {
            }

            public  OrganisationsEdit_ControlPanelFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  OrganisationsEdit_SalesPortalFeature : BrowserTestFeature
        {
            public  OrganisationsEdit_SalesPortalFeature()
            {
            }

            public  OrganisationsEdit_SalesPortalFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
}
namespace  Specs.Features.Purchases
{
    #region Using Directives
    
    using System.Diagnostics;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using Endjin.SpecFlow.Selenium.Framework;
    using Endjin.SpecFlow.Selenium.Framework.Features;

    #endregion

        public partial class  DelegatedPurchaseFeature : BrowserTestFeature
        {
            public  DelegatedPurchaseFeature()
            {
            }

            public  DelegatedPurchaseFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
        public partial class  PurchaseFeature : BrowserTestFeature
        {
            public  PurchaseFeature()
            {
            }

            public  PurchaseFeature(string platform, string browser, string browserVersion)
                : base(platform, browser, browserVersion)
            {
            }
        }
}
