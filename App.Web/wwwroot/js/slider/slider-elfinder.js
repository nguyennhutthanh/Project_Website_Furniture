$(document).ready(function () {
	$('.btn-elfinder').click(function (e) {
		let imgPath = $(e.target).attr("data-imgpath");
		let button = $(".position-relative");
		let image = button.find(".selectedImages");
		var fm = $('<div/>').dialogelfinder({
			url: '/file-manager/connector',
			baseUrl: "/lib/elfinder/",
			lang: 'vi',
			width: 840,
			height: 450,
			destroyOnClose: true,
			getFileCallback: function (files, fm) {
				var domain = window.location.origin + "/";
				let resultPath = files.url.replace(domain, "/");
				if (imgPath != "") {
					$(image).html(`<img class="image-review" src ="${resultPath}" />`);
				}
				if (files.mime != 'directory') {
					$(imgPath).val(resultPath);
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
