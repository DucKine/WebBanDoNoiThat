var WishList = {
	init: function () {
		WishList.regEvents();
	},
	regEvents: function () {

		$(document).on('click', '.wishlist', function () {
			debugger;
			
			$.ajax({
				url: '/Home/Create',
				data: { ProductID: $(this).data('id') },
				dataType: 'json',
				type: 'POST',
				success: (res) => {
					$('.reload-wish').load('/Home/Index .reload-wish');
					}
			});
		}
		);
		$(document).on('click', '.wishlistDisLike', function () {
			debugger;
			$.ajax({
				url: '/WishList/Remove',
				data: { ProductID: $(this).data('id') },
				dataType: 'json',
				type: 'POST',
				success: (res) => {
					$('.reload-wish').load('/Home/Index .reload-wish');
				}
			})
		});
		
	}
}

WishList.init();