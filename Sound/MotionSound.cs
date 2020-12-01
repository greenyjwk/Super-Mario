using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1;

namespace Mario.Sound
{
    public class SoundManager
    {
		private static SoundManager instance = new SoundManager();
		public static SoundManager Instance { get => instance; set => instance = value; }

		private static IDictionary<string, SoundEffect> soundEffectDictionary = new Dictionary<string, SoundEffect>();
		private static IDictionary<string, Song> songDictionary = new Dictionary<string, Song>();
 

        public static void StopSong(){
			MediaPlayer.Stop();
        }


		public static void loadcontent(ContentManager content)
		{
			soundEffectDictionary = new Dictionary<string, SoundEffect>
			{
				{SoundString.breakBlock, content.Load<SoundEffect>(SoundString.breakBlock)},
				{SoundString.bump, content.Load<SoundEffect>(SoundString.bump) },
				{SoundString.flip, content.Load<SoundEffect>(SoundString.flip) },
				{SoundString.marioCoin, content.Load<SoundEffect>(SoundString.marioCoin) },
				{SoundString.marioDie, content.Load<SoundEffect>(SoundString.marioDie) },
				{SoundString.marioFireball,content.Load<SoundEffect>(SoundString.marioFireballTexture) },
				{SoundString.marioJump , content.Load<SoundEffect>(SoundString.marioJump) },
				{SoundString.marioOneUp,content.Load<SoundEffect>(SoundString.marioOneUp) },
				{SoundString.marioPowerUp,content.Load<SoundEffect>(SoundString.marioPowerUp) },
				{SoundString.pipeTravel, content.Load<SoundEffect>(SoundString.pipeTravel) },
				{SoundString.powerUpAppears, content.Load<SoundEffect>(SoundString.powerUpAppears) },
				{SoundString.stomp, content.Load<SoundEffect>(SoundString.stompTexture) },
				{SoundString.takeDamage, content.Load<SoundEffect>(SoundString.takeDamage) },
				{SoundString.clearStage , content.Load<SoundEffect>(SoundString.clearStage)},
				{SoundString.gameOver, content.Load<SoundEffect>(SoundString.gameOver)},
				{SoundString.timeRunningOut, content.Load<SoundEffect>(SoundString.timeRunningOut)}
			};
			songDictionary = new Dictionary<string, Song>{
				{SoundString.starMarioMusic,content.Load<Song>(SoundString.starMarioMusic) },
				{SoundString.marioBGM, content.Load<Song>(SoundString.marioBGM)}
			};
		}
		public void PlaySoundEffect(string soundEffectName)
		{
			soundEffectDictionary[soundEffectName].Play();
		}
		public void PlayBGM(string songName)
		{
			MediaPlayer.Play(songDictionary[songName]);
		}        
    }
}
