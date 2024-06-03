mergeInto(LibraryManager.library, {

  GetPlayerData: function () {
    myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("small"));
  },

  RateGame: function () {
    ysdk.feedback.canReview()
        .then(({ value, reason }) =>{
            if (value) {
              ysdk.feedback.requestReview()
                  .then(({ feedbackSent }) => {
                    console.log(feedbackSent);
                  })
            } else {
                console.log(reason);
            }
        })
  },

  SaveExtern: function (date) {
    var dateString = UTF8ToString(date);
    var myobj = JSON.parse(dateString);
    player.setData(myobj);
  },

  LoadExtern: function () {
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
    });
  },

  Authorization: function() {
        initPlayer().then(_player => {
          if (_player.getMode() === 'lite') {
              // Игрок не авторизован.
            ysdk.auth.openAuthDialog().then(() => {
                      // Игрок успешно авторизован
              initPlayer().catch(err => {
                          // Ошибка при инициализации объекта Player.
              });
            }).catch(() => {
                    // Игрок не авторизован.
            });
          }
        }).catch(err => {
          // Ошибка при инициализации объекта Player.
        });
  },

});