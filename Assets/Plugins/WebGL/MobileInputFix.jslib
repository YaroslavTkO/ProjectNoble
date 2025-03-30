mergeInto(LibraryManager.library, {
    FixMobileInput: function() {
        document.addEventListener("touchcancel", function(event) {
            SendMessage("ButtonHandler", "ForceRelease");
        });

        document.addEventListener("touchend", function(event) {
            SendMessage("ButtonHandler", "ForceRelease");
        });
    }
});