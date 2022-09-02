$(document).ready(function (e) {
	var urllocal = $(location).attr('href');
	var ul = $("#Sub-nav-list").find('li').find('a');
	let resultTarget = $("#data-slug").data("id")
	let slugCate = `${window.location.origin}/News?slug=${resultTarget}`;
	for (let i = 0; i < ul.length; i++) {
		if (ul[i].href === urllocal) {
			$(ul[i]).parent().addClass('current');
		}
		if (ul[i].href === slugCate) {
			$(ul[i]).parent().addClass('current');
		}
	}
});
