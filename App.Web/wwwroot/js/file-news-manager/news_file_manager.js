
$(document).ready(function () {
	$('.btn-elfinder').click(function (e) {
		let imgThumbnailPath = $(e.target).attr("data-imgthumbnailpath");
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
				let thumbnailPath = files.tmb.replace(domain, "/");
				if (imgPath != "" && imgThumbnailPath != "") {
					$(image).html(`<img class="image-review" src ="${resultPath}" />`);
				}
				if (files.mime != 'directory') {
					$(imgThumbnailPath).val(thumbnailPath);
					$(imgPath).val(resultPath)
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
		console.log(fm)
	});
});
