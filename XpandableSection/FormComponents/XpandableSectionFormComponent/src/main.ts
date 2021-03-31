import App from './app.svelte';

const app = new App({
  target: document.getElementById('xpandableSectionRoot'),
  props: {
    valueBinding: document.getElementById('xpandableSectionData'),
    resources: JSON.parse((document.getElementById('xpandableSectionResources') as HTMLInputElement).value),
  },
});

export default app;
