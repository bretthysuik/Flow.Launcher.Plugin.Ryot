# Flow.Launcher.Plugin.Ryot

A plugin for [Flow Launcher](https://github.com/Flow-Launcher/Flow.Launcher) to search your [ryot](https://github.com/IgnisDa/ryot) tracker.

![image](https://imgur.com/AKBVT4a.gif)

### Configuration

The following configuration options are required, after installing the plugin:

| Option | Description | Example |
|--------|-------------|---------|
| Base URL | Base URL of your ryot instance, without a trailing `/` | http://192.168.0.101:9000 |
| API Token | API token generated from the `/settings/imports-and-exports` page | `eyJ0eXAiOiJKV1QiLCJhbGciOiJIUz...`


### Usage

| Keyword | Description | Example |
|---------|-------------|---------|
| `ryot audio_book\|audiobook\|abook\|ab <audiobook title>` | Search your audiobooks by title | `ryot ab The Final Empire` |
| `ryot anime <anime title>` | Search your anime by title | `ryot anime Naruto` |
| `ryot book\|b <book title>` | Search your books by title | `ryot b The Way of Kings` |
| `ryot podcast\|pod\|pc <podcast title>` | Search your podcasts by title | `ryot pod Flipping the Bird` |
| `ryot manga <manga title>` | Search your manga by title | `ryot manga Naruto` |
| `ryot movie\|mov\|m <movie title>` | Search your movies by title | `ryot m Avatar` |
| `ryot show\|tvshow\|tv <show title>` | Search your TV shows by title | `ryot tv The Sopranos` |
| `ryot video_game\|videogame\|vg <videogame title>` | Search your video games by title | `ryot vg Zelda` |
