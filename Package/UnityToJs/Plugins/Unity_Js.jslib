mergeInto(LibraryManager.library, {
	Init : function()
	{
		var script = document.createElement("script");
		script.src = "https://h.api.4399.com/h5mini-2.0/h5api-interface.php";
		document.body.appendChild(script);

		script = document.createElement("script");
        script.innerHTML = "var JsMessage = '';  var MessageNum = 0;\
            function AddMessageToUnity(Tag, Message)\n\
            {\n\
                Tag = Tag.replace(':','`[0001]');\n\
                Message = Message.replace(':','`[0001]');\n\
                JsMessage += '<Message' + MessageNum + '>' + Tag + ':' + Message + '</Message' + MessageNum + '>';\n\
                MessageNum += 1;\n\
            }"
        document.body.appendChild(script);
	},
	UnityToJs : function(Tag, Content)
	{
		var Tag0 = Pointer_stringify(Tag);
		var Content0 = Pointer_stringify(Content);
		switch(Tag0)
		{
			case "PlayAd":
				window.h5api.playAd(function(obj){
					if (obj.code === 10001) {
						AddMessageToUnity("ShowMessage", "奖励已发放");
						AddMessageToUnity(Content0, "Succeed!");
						console.log("播放结束");
					}
				});
				break;
		}
	},
	JsToUnity: function()
    {
        var returnStr = JsMessage.toString();
		JsMessage = "";
		var bufferSize = lengthBytesUTF8(returnStr) + 1
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
});