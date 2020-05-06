module.exports = {
	mode: 'spa',
	head: {
		title: 'share-emotion-desktop'
	}, // Headers of the page
	loading: false, // Disable default loading bar
	build: {
		extend(config) {
			if (process.server && process.browser) {
				// Run ESLint on save
				config.module.rules.push({
					enforce: 'pre',
					test: /\.(js|vue)$/,
					loader: 'eslint-loader',
					exclude: /(node_modules)/
				})
			}
			// Extend only webpack config for client-bundle
			//if (process.browser) { config.target = 'electron-main' }
			if (process.browser) {
				config.target = 'electron-renderer'
			}
			//if (process.browser) { config.target = 'electron' }
			//config.target = 'electron-renderer'
		}
	},
	dev: process.env.NODE_ENV === 'DEV',
	css: [
		'@/assets/css/global.css'
	]
}