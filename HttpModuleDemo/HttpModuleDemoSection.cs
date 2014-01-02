using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HttpModuleDemo
{
    /*This is a custom configuration section in web.config to store values
     * ConfigurationSection needs to be inhertied to make it available in config
     * The decorator ConfigurationProperty has the text which has to be used in the web.config
     */
    public class HttpModuleDemoSection : ConfigurationSection
    {
        [ConfigurationProperty("beginText")]
        public BeginTextElement BeginText
        {
            get
            { return (BeginTextElement)this["beginText"]; }
            set
            {
                this["beginText"] = value;
            }

        }

        [ConfigurationProperty("endText")]
        public EndTextElement EndText
        {
            get
            { return (EndTextElement)this["endText"]; }
            set
            {
                this["endText"] = value;
            }

        }
    }

    public class BeginTextElement : ConfigurationElement
    {
        [ConfigurationProperty("text")]
        public String Text
        {
            get
            {
                return (String)this["text"];
            }
            set
            {
                this["text"] = value;
            }
        }

    }
    public class EndTextElement : ConfigurationElement
    {
        [ConfigurationProperty("text")]
        public String Text
        {
            get
            {
                return (String)this["text"];
            }
            set
            {
                this["text"] = value;
            }
        }
    }
}