﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTesting.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UnitTesting.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {&quot;coord&quot;:{&quot;lon&quot;:-0.13,&quot;lat&quot;:51.51},&quot;weather&quot;:[{&quot;id&quot;:300,&quot;main&quot;:&quot;Drizzle&quot;,&quot;description&quot;:&quot;light intensity drizzle&quot;,&quot;icon&quot;:&quot;09d&quot;}],&quot;base&quot;:&quot;stations&quot;,&quot;main&quot;:{&quot;temp&quot;:280.32,&quot;pressure&quot;:1012,&quot;humidity&quot;:81,&quot;temp_min&quot;:279.15,&quot;temp_max&quot;:281.15},&quot;visibility&quot;:10000,&quot;wind&quot;:{&quot;speed&quot;:4.1,&quot;deg&quot;:80},&quot;clouds&quot;:{&quot;all&quot;:90},&quot;dt&quot;:1485789600,&quot;sys&quot;:{&quot;type&quot;:1,&quot;id&quot;:5091,&quot;message&quot;:0.0103,&quot;country&quot;:&quot;GB&quot;,&quot;sunrise&quot;:1485762037,&quot;sunset&quot;:1485794875},&quot;id&quot;:2643743,&quot;name&quot;:&quot;London&quot;,&quot;cod&quot;:200}.
        /// </summary>
        internal static string LondonCurretWeatherJsonResponse {
            get {
                return ResourceManager.GetString("LondonCurretWeatherJsonResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {&quot;cod&quot;:&quot;200&quot;,&quot;message&quot;:0.0032,&quot;cnt&quot;:36,&quot;list&quot;:[{&quot;dt&quot;:1487246400,&quot;main&quot;:{&quot;temp&quot;:286.67,&quot;temp_min&quot;:281.556,&quot;temp_max&quot;:286.67,&quot;pressure&quot;:972.73,&quot;sea_level&quot;:1046.46,&quot;grnd_level&quot;:972.73,&quot;humidity&quot;:75,&quot;temp_kf&quot;:5.11},&quot;weather&quot;:[{&quot;id&quot;:800,&quot;main&quot;:&quot;Clear&quot;,&quot;description&quot;:&quot;clear sky&quot;,&quot;icon&quot;:&quot;01d&quot;}],&quot;clouds&quot;:{&quot;all&quot;:0},&quot;wind&quot;:{&quot;speed&quot;:1.81,&quot;deg&quot;:247.501},&quot;sys&quot;:{&quot;pod&quot;:&quot;d&quot;},&quot;dt_txt&quot;:&quot;2017-02-16 12:00:00&quot;},{&quot;dt&quot;:1487257200,&quot;main&quot;:{&quot;temp&quot;:285.66,&quot;temp_min&quot;:281.821,&quot;temp_max&quot;:285.66,&quot;pressure&quot;:970.91,&quot;sea_level&quot;:1044.32,&quot;grnd [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string LondonForecastJsonResponse {
            get {
                return ResourceManager.GetString("LondonForecastJsonResponse", resourceCulture);
            }
        }
    }
}
