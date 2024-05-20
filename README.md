Back to Karma, Oyun ve Uygulama Akademisi 2024 AI Odaklı Game Jam'i için Unity 73. takım tarafından hazırlanmıştır. (Evsanur Gökçe Renk & Zeynep Sena Tatlı)
Buradaki scriptler oyunumuza aittir.

Oyunumuzda ML öğrenmesi modeli kullanıldı. MNIST sayı veri setini resimlerden algılayarak sınıflandırabilen eğitilmiş bir CNN modeli import edilerek oyunun içine yerleştirildi.

Oyun içerisinde oyuncunun bir tahtaya sayı yazması ile eğitilmiş MNIST modelinin yazıyı tahmin edbildi ve sınıflandırdı. 
DrawOnTexture.cs kodu ile oyun içerisindeki temsili tahta üzerine çizim yapılabilir hale geldi.
GetInferenceFromModel.cs kodu ile çizilen sayı resim olarak modele gönderildi ve MNIST modelinin yazılan sayıyı tahmin etmesi sağlandı.
Yazılan sayı UI ile etkileşimli olarak ekranda görüntülendi.

Diğer kodlarda ise karakter hareketleri ve komboları, diyalog sistemleri ve envanter sistemi gibi oyunun temel taşları yer almaktadır.

----

Back to Karma, Oyun ve Uygulama Akademisi 2024 AI-Focused Game Jam was prepared by Team 73 using Unity. (Evsanur Gökçe Renk & Zeynep Sena Tatlı)
The scripts here belong to our game.

In our game, a machine learning model was used. A trained CNN model capable of classifying the MNIST digit dataset from images was imported and integrated into the game.

Within the game, when the player writes a number on a board, the trained MNIST model predicts and classifies the writing.
With the DrawOnTexture.cs script, drawing on the virtual board in the game is made possible.
With the GetInferenceFromModel.cs script, the drawn number is sent to the model as an image, and the MNIST model predicts the written number.
The written number is interactively displayed on the screen via the UI.

Other scripts include the core elements of the game such as character movements and combos, dialogue systems, and the inventory system.

---
For the gameplay our game: https://www.youtube.com/watch?v=M8yuqykUJO8
