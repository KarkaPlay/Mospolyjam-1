mergeInto(LibraryManager.library, {

  GetYandexPlayerData: function () {
    myGameInstance.SendMessage('Yandex', 'SetNameText', player.getName());
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));

    console.log(player.getName());
    console.log(player.getPhoto("medium"));
  },

  AskYandexForRate: function () {
    console.log("Вызвана функция AskYandexForRate");
    ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            console.log("canReview = true");
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log("Отправили оценку");
                        console.log(feedbackSent);
                        myGameInstance.SendMessage('Yandex', 'GameRated');
                    })
            } else {
                console.log("Не получилось потому что");
                console.log(reason)
            }
        })
  },

  SaveExtern: function (data) {
    console.log("Запустился SaveExtern");
    var dataString = UTF8ToString(data);
    var newDataObj = JSON.parse(dataString);
    player.setData(newDataObj);
    console.log("Сохранили данные");
  },

  LoadExtern: function () {
    console.log("Запустился LoadExtern");
    player.getData().then(_data => {
      const myJSON = JSON.stringify(_data);
      myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
      console.log("Данные:");
      console.log(myJSON);
    });
    console.log("Загрузили данные");
  },

  ShowAdv: function(){
    myGameInstance.SendMessage('Player', 'StopSounds');
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          // some action after close
          myGameInstance.SendMessage('Player', 'ContinueSounds');
        },
        onError: function(error) {
          // some action on error
        }
    }
    })
  },

});