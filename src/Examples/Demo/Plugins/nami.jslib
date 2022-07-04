mergeInto(LibraryManager.library, {

    LoadBaseAddress: function () {
      window.cardano.nami.enable().then(function(api) {
        api.getUsedAddresses().then(function(addrs) {
          localStorage.setItem('NamiBaseAddress', addrs[0]);
        })
      })
    },

    GetBaseAddress: function () {
      var addr = localStorage.getItem('NamiBaseAddress');
      if (!addr) return "";
      var bufferSize = lengthBytesUTF8(addr) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(addr, buffer, bufferSize);
      return buffer;
    },

    ClearBaseAddress: function () {
      localStorage.removeItem('NamiBaseAddress');
    }

});
