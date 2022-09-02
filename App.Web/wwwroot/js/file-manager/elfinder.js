﻿$(function () {
	$(document).ready(function () {
		var myCommands = elFinder.prototype._options.commands;
		var disabled = ['callback', 'chmod', 'editor', 'netmount', 'ping', 'help']; // Not yet implemented commands in elFinder.NetCore
		elFinder.prototype.i18.en.messages.TextArea = "Edit";
		elFinder.prototype.i18.en.messages.errNewNameSelection = 'Unable to create new file with name "$1"';

		$.each(disabled, function (i, cmd) {
			(idx = $.inArray(cmd, myCommands)) !== -1 && myCommands.splice(idx, 1);
		});

		var options = {
			baseUrl: "/lib/elfinder/",
			url: '/file-manager/connector', // Default (Local File System)
			//customData: { folder: '@Model.Folder', subFolder: '@Model.SubFolder' }, // customData passed in every request to the connector as query strings. These values are used in FileController's Index method.
			rememberLastDir: false, // Prevent elFinder saving in the Browser LocalStorage the last visited directory
			commands: myCommands,
			//lang: 'pt_BR', // elFinder supports UI and messages localization. Check the folder Content\elfinder\js\i18n for all available languages. Be sure to include the corresponding .js file(s) in the JavaScript bundle.
			uiOptions: { // UI buttons available to the user
				toolbar: [
					['back', 'forward'],
					['reload'],
					['home', 'up'],
					['mkdir', 'mkfile', 'upload'],
					['open', 'download'],
					['undo', 'redo'],
					['info'],
					['quicklook'],
					['copy', 'cut', 'paste'],
					['rm'],
					['duplicate', 'rename', 'edit'],
					['selectall', 'selectnone', 'selectinvert'],
					['view', 'sort'],
					['search']
				]
			},
			//onlyMimes: ["image", "text/plain"] // Get files of requested mime types only
			lang: 'vi', // Change language
			height: '72%',
			resizable: false,
		};
		$('#elfinder').elfinder(options).elfinder('instance');
	});
});
