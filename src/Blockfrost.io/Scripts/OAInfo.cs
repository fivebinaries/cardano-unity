
using System;
using UnityEngine;

namespace Blockfrost {

    [Serializable]
    public class OAInfo : ScriptableObject {
        public string Title;
        public string Description;
        public string Version;
        public string TermsOfService;
        public OAContact Contact;
        public OALicense License;
    }

    [Serializable]
    public class OAContact {
        public string Name;
        public string Url;
        public string Email;
    }

    [Serializable]
    public class OALicense {
        public string Name;
        public string Url;
    }
}