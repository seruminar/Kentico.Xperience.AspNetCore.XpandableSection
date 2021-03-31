import App from './app.svelte';

const app = new App({
  target: document.getElementById('styleEditorRoot'),
  props: {
    valueBinding: document.getElementById('styleEditorStyles'),
    resources: JSON.parse((document.getElementById('styleEditorResources') as HTMLInputElement).value),
  },
});

export default app;
