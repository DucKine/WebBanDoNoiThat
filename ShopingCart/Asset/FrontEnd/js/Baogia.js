var baogia = {
    innit: function () {
        baogia.registerEvent();
    },
    registerEvent: () => {
        $('#Frombaogia').validate({
            rules: {
                phone: {
                    required: true,
                    number: true
                },
                email: {
                    required: true,
                    email: true
                },
                name: "required",
                message: "required"
            },

            messages: {
                name: "Bạn Phải Nhập Tên",
                phone: {
                    required: "Bạn Phải Nhập Số Điện Thoại",
                    number: "Số Điện Thoại Phải Là Số"
                },
                email: {
                    required: "Bạn Phải Nhập Email",
                    email: "Email Phải đúng định dạng"
                },
                message: "Bạn Phải Nhập Messgage",
            }
        });

        $('#SendNow').off('click').on('click', () => {
            if ($('#Frombaogia').valid()) {
                var name = $('#name').val();
                var email = $('#email').val();
                var phone = $('#phone').val();
                var message = $('#message').val();
                $.ajax({
                    url: '/Baogia/Send',
                    type: 'POST',
                    dataType: 'json',
                    data: {
                        name: name,
                        email: email,
                        phone: phone,
                        message: message
                    },
                    success: (res) => {
                        if (res.status == true) {
                            alert('Chúng Tôi Sẽ Phản Hồi Ý Kiến Của Bạn');
                            baogia.resetFrom();
                        }
                    }
                })
            }
        });


    },
    resetFrom: () => {
        $('#name').val('');
        $('#email').val('');
        $('#phone').val('');
        $('#message').val('')
    }
     
}
baogia.innit();