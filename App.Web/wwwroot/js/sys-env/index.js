$(document).ready(function () {
	$('.btn-elfinder').click(function (e) {
		let inputPath = $(e.target).attr("data-input");
		var fm = $('<div/>').dialogelfinder({
			url: '/file-manager/connector',
			baseUrl: "/lib/elfinder/",
			lang: 'vi',
			width: 840,
			height: 450,
			destroyOnClose: true,
			getFileCallback: function (files, fm) {
				var domain = window.location.origin;
				let resultPath = files.url.replace(domain, "/");
				console.log(resultPath);
				$(inputPath).val(resultPath);
				if (files.mime != 'directory') {
					fm.destroy();
					return false;
				}
			},
			commandsOptions: {
				getfile: {
					oncomplete: 'close',
					folders: false
				}
			}
		}).dialogelfinder('instance');
	});
});
